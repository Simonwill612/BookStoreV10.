using System;
using System.Collections.Generic;

namespace BookStoreV10.Models;

public partial class StoreOwner
{
    public int StoreOwnerId { get; set; }

    public int? UserName { get; set; }

    public string? Password { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
