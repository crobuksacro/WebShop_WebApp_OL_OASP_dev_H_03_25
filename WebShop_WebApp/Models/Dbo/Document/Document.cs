using System.ComponentModel.DataAnnotations;
using WebShop_Shared.Model.Base.Document;
using WebShop_Shared.Model.Interfaces;

namespace WebShop_WebApp.Models.Dbo.Document
{
    public class Document: DocumentBase, IBaseTableAtributes
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Valid { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser? Buyer { get; set; }


    }
}
