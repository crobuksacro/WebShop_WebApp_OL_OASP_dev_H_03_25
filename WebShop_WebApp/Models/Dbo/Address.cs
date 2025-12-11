using System.ComponentModel.DataAnnotations;
using WebShop_Shared.Model.Base;
using WebShop_Shared.Model.Interfaces;

namespace WebShop_WebApp.Models.Dbo
{
    public class Address : AddressBase, IBaseTableAtributes
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Valid { get; set; }

    }
}
