using Ferrex.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ferrex.Data
{
    public class FerrexContext : IdentityDbContext
    {
        public FerrexContext(DbContextOptions<FerrexContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<TransportOrder> TransportOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                            .HasOne(p => p.Category)
                            .WithMany()
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductOrder>()
                .Property(p => p.CreatedOn).ValueGeneratedOnAdd();
            builder.Entity<ProductOrder>()
                .Property(p => p.ReviewedOn).HasDefaultValue(new DateTime());

            builder.Entity<TransportOrder>()
                .Property(p => p.CreatedOn).ValueGeneratedOnAdd();
            builder.Entity<TransportOrder>()
                .Property(p => p.ReviewedOn).HasDefaultValue(new DateTime());

            base.OnModelCreating(builder);
        }
    }
}
