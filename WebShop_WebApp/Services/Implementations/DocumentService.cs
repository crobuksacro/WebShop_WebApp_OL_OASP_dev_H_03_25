using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.Dto.Document;
using WebShop_Shared.Model.ViewModel.Document;
using WebShop_WebApp.Data;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Models.Dbo.Document;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        public DocumentService(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <summary>
        /// Get document by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="documentId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetDocumentAsync<T>(long documentId)
        {
            var document = await _db.Documents
                .Include(y=>y.Buyer)
                .FirstOrDefaultAsync(x => x.Id == documentId);

            //switch (document.DocumentType)
            //{
            //    case DocumentType.Invoice:
            //        var invoice = JsonSerializer.Deserialize<InvoiceDto>(document.Data);
            //        invoice.BuyerId = document.Buyer != null ? document.Buyer.Id : null;
            //     return (T)Convert.ChangeType(invoice, typeof(T));


            //    case DocumentType.Offer:
            //        break;
            //    case DocumentType.Receipt:
            //        break;
            //    case DocumentType.DeliveryNote:
            //        break;
            //    case DocumentType.WarrantyCertificate:
            //        break;
            //    case DocumentType.ReturnForm:
            //        break;
            //    default:
            //        break;
            //}

            //if (document == null)
            //{
            //    throw new Exception("Document not found");
            //}
            return JsonSerializer.Deserialize<T>(document.Data);
        }




        /// <summary>
        /// Save document to db
        /// </summary>
        /// <param name="createdBy"></param>
        /// <param name="documentType"></param>
        /// <param name="documentStatus"></param>
        /// <param name="data"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<DocumentViewModel> SaveDocumentAsync(ApplicationUser createdBy, DocumentType documentType, DocumentStatus documentStatus, object data, ApplicationUser? buyer = null)
        {

            var document = new Document
            {
                Data = JsonSerializer.Serialize(data),
                CreatedBy = createdBy,
                DocumentType = documentType,
                DocumentStatus = documentStatus,
                Buyer = buyer != null ? buyer : null
            };

            await _db.Documents.AddAsync(document);
            await _db.SaveChangesAsync();

            return _mapper.Map<DocumentViewModel>(document);
        }

        /// <summary>
        /// Get documents from db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<DocumentViewModel>> GetDocumentsAsync(GetDocumentBinding model)
        {
            if (!model.Active.HasValue)
            {
                model.Active = true;
            }

            var dbos =  _db.Documents
                .Include(x=>x.Buyer)
                .Where(y=>y.Valid == model.Active.Value);


            if (model.DocumentType.HasValue)
            {
                dbos = dbos.Where(x => x.DocumentType == model.DocumentType.Value);
            }

            if (model.DocumentStatus.HasValue)
            {
                dbos = dbos.Where(x => x.DocumentStatus == model.DocumentStatus.Value);
            }

            if (!string.IsNullOrWhiteSpace(model.BuyerId))
            {
                dbos = dbos.Where(x => x.Buyer != null && x.Buyer.Id == model.BuyerId);
            }


            var documents = await dbos.ToListAsync();


            return _mapper.Map<List<DocumentViewModel>>(documents);
        }



    }
}
