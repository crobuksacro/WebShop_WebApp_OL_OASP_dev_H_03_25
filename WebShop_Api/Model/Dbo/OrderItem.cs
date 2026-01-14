using System;
using System.Collections.Generic;

namespace WebShop_Api.Model.Dbo;

public partial class OrderItem
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public bool Valid { get; set; }

    public long? ProductId { get; set; }

    public long? OrderId { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
