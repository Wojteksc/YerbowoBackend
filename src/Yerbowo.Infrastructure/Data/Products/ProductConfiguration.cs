using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yerbowo.Domain.Products;

namespace Yerbowo.Infrastructure.Data.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Subcategory)
                .WithMany(c => c.Products)
                .IsRequired();

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
