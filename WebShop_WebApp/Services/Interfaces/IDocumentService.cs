using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.Document;
using WebShop_WebApp.Models.Dbo;

namespace WebShop_WebApp.Services.Interfaces
{
    public interface IDocumentService
    {

        /// <summary>
        /// Get document by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="documentId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<T> GetDocumentAsync<T>(long documentId);
        /// <summary>
        /// Save document to db
        /// </summary>
        /// <param name="createdBy"></param>
        /// <param name="documentType"></param>
        /// <param name="documentStatus"></param>
        /// <param name="data"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        Task<DocumentViewModel> SaveDocumentAsync(ApplicationUser createdBy, DocumentType documentType, DocumentStatus documentStatus, object data, ApplicationUser? buyer = null);
        /// <summary>
        /// Get documents from db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<DocumentViewModel>> GetDocumentsAsync(GetDocumentBinding model);
    }
}