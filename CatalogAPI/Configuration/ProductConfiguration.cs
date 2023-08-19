using CatalogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogAPI.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.ImageUrl).HasMaxLength(250);
            builder.Property(p => p.RegisterDate).IsRequired();
            builder.HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(c => c.CategoryId);
        }
    }
}
