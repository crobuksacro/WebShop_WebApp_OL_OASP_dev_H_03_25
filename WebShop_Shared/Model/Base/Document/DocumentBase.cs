using WebShop_Shared.Model.Dto;

namespace WebShop_Shared.Model.Base.Document
{
    public class DocumentBase
    {
        public string Data { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}
