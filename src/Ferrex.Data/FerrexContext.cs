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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                            .HasOne(p => p.Category)
                            .WithMany()
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>()
                .Property(p => p.CreatedOn).ValueGeneratedOnAdd();

            builder.Entity<Product>()
                .Property(p => p.CreatedOn).ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }
    }
}
