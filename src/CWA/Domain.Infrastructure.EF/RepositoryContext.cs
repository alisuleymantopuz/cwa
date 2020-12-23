using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Infrastructure.EF
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
          : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductsTags> ProductsTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<ProductsTags>().HasKey(t => new { t.TagId, t.ProductId });
            modelBuilder.Entity<ProductsTags>().HasOne<Product>(sc => sc.Product).WithMany(s => s.ProductsTags).HasForeignKey(sc => sc.ProductId);
            modelBuilder.Entity<ProductsTags>().HasOne<Tag>(sc => sc.Tag).WithMany(s => s.ProductsTags).HasForeignKey(sc => sc.TagId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var iphoneId = Guid.NewGuid();
            var iphone = new Product()
            {
                Id = iphoneId,
                Name = "IPhone X",
                ProductRegisterDate = DateTime.UtcNow,
                UnitPrice = 1000
            };
            modelBuilder.Entity<Product>().HasData(iphone);


            var mobilePhoneId = Guid.NewGuid();
            var mobilePhone = new Tag
            {
                Id = mobilePhoneId,
                Name = "Mobile phone"
            }; 
            modelBuilder.Entity<Tag>().HasData(mobilePhone);

            var mobilePhoneIphone = new ProductsTags { ProductId = iphoneId, TagId = mobilePhoneId };
            modelBuilder.Entity<ProductsTags>().HasData(mobilePhoneIphone);

        }
    }
}
