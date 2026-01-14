using System;
using System.Collections.Generic;

namespace WebShop_Api.Model.Dbo;

public partial class Order
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public bool Valid { get; set; }

    public decimal Total { get; set; }

    public string? BuyerId { get; set; }

    public long? OrderAddressId { get; set; }

    public int OrderStatus { get; set; }

    public string? Message { get; set; }

    public long? InvoiceId { get; set; }

    public virtual AspNetUser? Buyer { get; set; }

    public virtual Document? Invoice { get; set; }

    public virtual Addresss? OrderAddress { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
