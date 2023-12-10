using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreV10.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string? PublisherName { get; set; }

    public string? PublisherAddress { get; set; }

    public string? PublisherLogo { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
