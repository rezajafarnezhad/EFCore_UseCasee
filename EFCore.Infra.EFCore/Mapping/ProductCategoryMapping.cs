using EFCore.Domain.ProductCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Infra.EFCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(244).IsRequired();

            builder.HasMany(c => c.Products).WithOne(c => c.category).HasForeignKey(c=>c.CategoryId);
        }
    }
}
