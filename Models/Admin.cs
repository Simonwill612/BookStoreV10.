using System;
using System.Collections.Generic;

namespace BookStoreV10.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? Password { get; set; }

    public string? ImageUrl { get; set; }

    public string? Name { get; set; }
}
