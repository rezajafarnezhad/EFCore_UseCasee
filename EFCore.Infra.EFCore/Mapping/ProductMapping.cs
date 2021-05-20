using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Infra.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Domain.ProductAgg.Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(244).IsRequired();

            builder.HasOne(c => c.category).WithMany(c => c.Products).HasForeignKey(c=>c.CategoryId);
        }
    }
}
