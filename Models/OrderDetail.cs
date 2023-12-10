using System;
using System.Collections.Generic;

namespace BookStoreV10.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? BookId { get; set; }

    public string? ImageUrl { get; set; }

    public int Quantity { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Order? Order { get; set; }
}
