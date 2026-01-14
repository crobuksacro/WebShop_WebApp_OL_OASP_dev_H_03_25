using System;
using System.Collections.Generic;

namespace WebShop_Api.Model.Dbo;

public partial class Addresss
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public bool Valid { get; set; }

    public string Street { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<AspNetUser> AspNetUsers { get; set; } = new List<AspNetUser>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
