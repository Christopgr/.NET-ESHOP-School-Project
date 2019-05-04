using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ncs2019_team_TBD.Models;

namespace ncs2019_team_TBD.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public DbSet<Order> Orders { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public DbSet<Product> Products { get; set; }

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


			builder.Entity<Category>(entity =>
			{
				entity.ToTable("Categories");
				entity.HasKey(x => x.Id);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
			});

			builder.Entity<Material>(entity =>
			{
				entity.ToTable("Materials");
				entity.HasKey(x => x.Id);
				entity.HasMany(x => x.ProductMaterials);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
			});

			builder.Entity<Order>(entity =>
			{
				entity.ToTable("Orders");
				entity.HasKey(x => x.Id);
				entity.HasOne(x => x.User).WithMany(c => c.Orders).HasForeignKey(f => f.UserId);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
				entity.HasMany(x => x.OrderItems);
			});



			builder.Entity<ProductMaterial>(entity =>
			{
				entity.ToTable("ProductMaterials");
				//declare primary key with 2 foreign keys
				entity.HasKey(x => new { x.ProductId, x.MaterialId });

				entity.HasOne(x => x.Material)
				.WithMany(m => m.ProductMaterials)
				.HasForeignKey(pm => pm.MaterialId)
				.HasPrincipalKey(m => m.Id);

				entity.HasOne(x => x.Product)
				.WithMany(m => m.ProductMaterials)
				.HasForeignKey(pm => pm.ProductId)
				.HasPrincipalKey(m => m.Id);
			});

			builder.Entity<OrderItem>(entity =>
			{
				entity.ToTable("OrderItems");
				//declare primary key with 2 foreign keys
				entity.HasKey(x => new { x.ProductId, x.OrderId });
			});
			builder.Entity<Product>(entity =>
			{
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
			builder.Entity<Cart>(entity =>
			{
				entity.ToTable("Carts");
				entity.HasKey(x => x.Id);
				entity.HasOne(x => x.User).WithOne(c => c.Cart);
				entity.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
				entity.HasMany(x => x.CartItems);
			});
			builder.Entity<CartItem>(entity =>
			{
				entity.ToTable("CartItems");
				//declare primary key with 2 foreign keys
				entity.HasKey(x => new { x.ProductId, x.CartId });
				entity.HasOne(x => x.Product)
				.WithMany(p => p.CartItems)
				.HasForeignKey(x => x.ProductId)
				.HasPrincipalKey(p => p.Id);

				entity.HasOne(x => x.Cart)
				.WithMany(c => c.CartItems)
				.HasForeignKey(a => a.CartId)
				.HasPrincipalKey(b => b.Id);

			});

		}

	}
}
