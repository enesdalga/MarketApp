using System;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.WebService.Models
{
    public class MarketContext:DbContext
    {
        public MarketContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
