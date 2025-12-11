using WebShop_Shared.Model.Dto;

namespace WebShop_Shared.Model.Binding
{
    public class GetDocumentBinding
    {
        public DocumentStatus? DocumentStatus { get; set; }
        public DocumentType? DocumentType { get; set; }
        public string? BuyerId { get; set; }
        public bool? Active { get; set; }

    }
}
