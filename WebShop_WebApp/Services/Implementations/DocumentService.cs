using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using WebShop_Shared.Model.Dto;
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
        /// Save document to db
        /// </summary>
        /// <param name="createdBy"></param>
        /// <param name="documentType"></param>
        /// <param name="documentStatus"></param>
        /// <param name="data"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<DocumentViewModel> SaveDocument(ApplicationUser createdBy, DocumentType documentType, DocumentStatus documentStatus, object data, ApplicationUser? buyer)
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



    }
}
