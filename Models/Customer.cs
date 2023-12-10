using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreV10.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Password { get; set; }

    public string? ImageUrl { get; set; }
    
    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
