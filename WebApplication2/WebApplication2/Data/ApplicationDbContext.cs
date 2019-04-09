using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Products> Products { get; set; }

        public DbSet<Materials> Materials { get; set; }

        public DbSet<Category> Categories { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);    //configuring Products
            builder.Entity<Products>(entity =>
         {
             entity.ToTable("products");
             entity.HasKey(x => x.Id);
             entity.HasOne(c => c.Category)
             .WithMany(p => p.Products)
             .HasForeignKey(f => f.CategoryId)
             .HasPrincipalKey(s => s.Id);
         });

            builder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");
                entity.HasKey(x => x.Id);    //diloneis Id oti einai primary  key to category
               
            });

            builder.Entity<Materials>(entity =>
            {
                entity.ToTable("materials");
                entity.HasKey(x => x.Id);

                entity.HasMany(x => x.ProductMaterials);

            });

            builder.Entity<ProductMaterials>(entity =>
            {
                entity.ToTable("Product Materials");
                entity.HasKey(x => new { x.ProductId, x.MaterialId });

            });
        }


    }

   
}


