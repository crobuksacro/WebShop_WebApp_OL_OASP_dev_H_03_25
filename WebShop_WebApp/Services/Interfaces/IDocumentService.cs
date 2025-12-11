using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.Document;
using WebShop_WebApp.Models.Dbo;

namespace WebShop_WebApp.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<DocumentViewModel> SaveDocumentAsync(ApplicationUser createdBy, DocumentType documentType, DocumentStatus documentStatus, object data, ApplicationUser? buyer = null);
    }
}