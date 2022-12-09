using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30).HasColumnType("varchar");

            builder.HasData(
                new Category { Id = 1, Name = "Telefon", Description = "Sıfır Telefonlar", CreatedDate = DateTime.Now },
                new Category { Id = 2, Name = "Beyaz Eşya", Description = "Beyaz Eşya", CreatedDate = DateTime.Now },
                new Category { Id = 3, Name = "Bilgisayar", Description = "Laptoplar", CreatedDate = DateTime.Now });
        }
    }
}
