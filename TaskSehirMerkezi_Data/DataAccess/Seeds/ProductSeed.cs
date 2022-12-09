using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Brand).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            builder.Property(x => x.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

            builder.HasData(
              new Product { Id = 1, CategoryId = 1, Name = "Galaxy M-20", Stock = 22, UnitPrice = 22, Brand = "Samsung", Description = "Samsung Ürünü Güzel", CreatedDate = DateTime.Now },
              new Product { Id = 2, CategoryId = 2, Name = "Buzdolabı", Stock = 12, UnitPrice = 20, Brand = "Arçelik", Description = "Arçelik Ürün Şahane", CreatedDate = DateTime.Now },
              new Product { Id = 3, CategoryId = 3, Name = "Huawei Matebook m20", Stock = 13, UnitPrice = 12, Brand = "Huawei", Description = "Huawei Ürün artıları fazla", CreatedDate = DateTime.Now });
        }
    }
}
