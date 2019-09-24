using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XmlTest.EntityFramework.Models;

namespace XmlTest.EntityFramework
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
		  : base(options)
		{ }

		public DbSet<Order> Orders { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<OrderArticle> OrderArticles { get; set; }
		public DbSet<BillingAddress> BillingAddresses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>(builder =>
			{
				builder.HasKey(z => z.Oxid);

				builder.Property(z => z.Oxid)
					.HasColumnType("bigint")
					.ValueGeneratedNever();

				builder.HasMany(z => z.Payments)
					.WithOne(z => z.Order)
					.HasForeignKey(z => z.OrderId);

				builder.HasMany(z => z.Articles)
					.WithOne(z => z.Order)
					.HasForeignKey(z => z.OrderId);

				builder.HasOne(z => z.BillingAddress)
					.WithOne(z => z.Order);
			});

			modelBuilder.Entity<Payment>(builder =>
			{
				builder.HasKey(z => z.Id);
			});

			modelBuilder.Entity<OrderArticle>(builder =>
			{
				builder.HasKey(z => z.ArtNum);

				builder.Property(z => z.ArtNum)
					.ValueGeneratedNever();
			});

			modelBuilder.Entity<BillingAddress>(builder =>
			{
				builder.HasKey(z => z.Id);
			});
		}
	}
}
