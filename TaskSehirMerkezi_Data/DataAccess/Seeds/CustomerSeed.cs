using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSehirTeknolojileri_Data.Entities.Concrete;

namespace TaskSehirTeknolojileri_Data.DataAccess.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.City).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(13).HasColumnType("varchar");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            builder.Property(x => x.Address).IsRequired().HasMaxLength(60).HasColumnType("varchar");
            builder.HasData(
                new Customer { Id = 1, FirstName = "Ramazan", LastName = "Küçükkoç", City = "Konya", PhoneNumber = "5436251369", Email = "ramazankucukkoc43@gmail.com", Address = "Fetih Mah. Aşık Nigari Sok. NO:2AB" },
                new Customer { Id = 2, FirstName = "Aliş", LastName = "Tufan", City = "Ankara", PhoneNumber = "5427123456", Email = "alistfn06@gmail.com", Address = "Sincan Mah. Aşık Nigari Sok. NO:2AB" }
                );

        }
    }
}
