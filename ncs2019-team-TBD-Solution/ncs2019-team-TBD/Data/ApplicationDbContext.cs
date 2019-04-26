﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ncs2019_team_TBD.Models;

namespace ncs2019_team_TBD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<ProductMaterial> ProductMaterials { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			//Create the relations between tables
			builder.Entity<Product>(entity => {
				entity.ToTable("Products");
				//declare primary key
				entity.HasKey(x => x.Id);
				//declare foreign key and that a Category has many Products (1 to many relation)
				entity.HasOne(x => x.Category).WithMany(c => c.Products).HasForeignKey(f => f.CategoryId);
				//declare that Product can be in many ProductMaterials
				entity.HasMany(x => x.ProductMaterials);
				entity.HasMany(x => x.OrderItems);
				entity.HasMany(x => x.CartItems);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
			});

			builder.Entity<Category>(entity => {
				entity.ToTable("Categories");
				entity.HasKey(x => x.Id);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
			});

			builder.Entity<Material>(entity => {
				entity.ToTable("Materials");
				entity.HasKey(x => x.Id);
				entity.HasMany(x => x.ProductMaterials);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
			});

			builder.Entity<Order>(entity => {
				entity.ToTable("Orders");
				entity.HasKey(x => x.Id);
				entity.HasOne(x => x.User).WithMany(c => c.Orders).HasForeignKey(f => f.UserId);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
				entity.HasMany(x => x.OrderItems);
			});

			builder.Entity<Cart>(entity => {
				entity.ToTable("Carts");
				entity.HasKey(x => x.Id);
				entity.HasOne(x => x.User);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
				entity.HasMany(x => x.CartItems);
			});

			builder.Entity<ProductMaterial>(entity => {
				entity.ToTable("ProductMaterials");
				//declare primary key with 2 foreign keys
				entity.HasKey(x => new { x.ProductId, x.MaterialId });
			});

			builder.Entity<OrderItem>(entity => {
				entity.ToTable("OrderItems");
				//declare primary key with 2 foreign keys
				entity.HasKey(x => new { x.ProductId, x.OrderId });
			});

			builder.Entity<CartItem>(entity => {
				entity.ToTable("CartItems");
				//declare primary key with 2 foreign keys
				entity.HasKey(x => new { x.ProductId, x.CartId });
			});
			
		}
	}
}
