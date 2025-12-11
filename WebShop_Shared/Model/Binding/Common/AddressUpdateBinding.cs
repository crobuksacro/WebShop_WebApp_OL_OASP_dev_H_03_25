using WebShop_Shared.Model.Base;

namespace WebShop_Shared.Model.Binding.Common
{
    public class AddressUpdateBinding : AddressBase
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
    }
}
