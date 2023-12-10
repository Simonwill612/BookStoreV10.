using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreV10.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? AuthorName { get; set; }

    public string? PublisherName { get; set; }

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    [NotMapped]
    public IFormFile? CoverImageFile { get; set; }

    public byte[]? CoverImageData { get; set; }

    public int? StoreOwnerId { get; set; }

    public virtual Author? AuthorNameNavigation { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Publisher? PublisherNameNavigation { get; set; }

    public virtual StoreOwner? StoreOwner { get; set; }
}
