using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreV10.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int? CartId { get; set; }

    public int? BookId { get; set; }

    public string? ImageUrl { get; set; }

    public int? Quantity { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Cart? Cart { get; set; }
}
