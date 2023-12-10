using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreV10.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public string? AuthorAddress { get; set; }

    public string? AuthorEmail { get; set; }

    public string? AuthorPhoto { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
