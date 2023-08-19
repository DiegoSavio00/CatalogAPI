using CatalogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogAPI.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ImageUrl).HasMaxLength(250).IsRequired();
            builder.HasData(
                new Category(1, "Material Escolar", "material.jpg"),
                new Category(2, "Eletrônicos", "eletronicos.jpg"),
                new Category(3, "Acessórios", "acessorios.jpg")
                );
        }
    }
}
