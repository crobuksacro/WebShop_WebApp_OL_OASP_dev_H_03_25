namespace WebShop_Shared.Model.Base.OrderModels
{
    public abstract class OrderItemBase
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
