using System;
using System.Collections.Generic;

namespace WebShop_Api.Model.Dbo;

public partial class Document
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public bool Valid { get; set; }

    public string Data { get; set; } = null!;

    public int DocumentType { get; set; }

    public int DocumentStatus { get; set; }

    public string? BuyerId { get; set; }

    public string? CreatedById { get; set; }

    public virtual AspNetUser? Buyer { get; set; }

    public virtual AspNetUser? CreatedBy { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
