using System;
using System.Collections.Generic;

namespace WebShop_Api.Model.Dbo;

public partial class Product
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public bool Valid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public long? ProductCategoryId { get; set; }

    public decimal? Quantity { get; set; }

    public long? QuantityTypeId { get; set; }

    public string? ImgUrl { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual QuantityType? QuantityType { get; set; }
}
