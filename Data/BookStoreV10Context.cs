using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStoreV10.Models;

namespace BookStoreV10.Data
{
    public class BookStoreV10Context : DbContext
    {
        public BookStoreV10Context (DbContextOptions<BookStoreV10Context> options)
            : base(options)
        {
        }

        public DbSet<BookStoreV10.Models.Admin> Admin { get; set; } = default!;

        public DbSet<BookStoreV10.Models.Customer> Customers { get; set; } = default!;

        public DbSet<BookStoreV10.Models.Book> Book { get; set; } = default!;

        public DbSet<BookStoreV10.Models.Author> Author { get; set; } = default!;

        public DbSet<BookStoreV10.Models.Publisher> Publisher { get; set; } = default!;
    }
}
