using System;
using System.Collections.Generic;

namespace WebShop_Api.Model.Dbo;

public partial class ProductCategory
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public bool Valid { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
