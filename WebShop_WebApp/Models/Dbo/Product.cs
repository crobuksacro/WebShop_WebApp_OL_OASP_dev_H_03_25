using WebShop_Shared.Model.Base;

namespace WebShop_WebApp.Models.Dbo
{
    public class Product:ProductBase
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Valid { get; set; }

    }
}
