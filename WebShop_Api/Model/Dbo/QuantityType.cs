using System;
using System.Collections.Generic;

namespace WebShop_Api.Model.Dbo;

public partial class QuantityType
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public bool Valid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
