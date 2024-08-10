using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoodHamburger.Core.Models;

namespace GoodHamburger.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela bloco.
    /// </summary>
    public class SandwichMapping : IEntityTypeConfiguration<Sandwich>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Sandwich> builder)
        {
            builder.ToTable("Sandwich");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
             .IsRequired(true)
             .HasColumnType("NVARCHAR")
             .HasMaxLength(100);

            builder.HasMany(x => x.Extra)
                .WithOne()
                .HasForeignKey(x => x.SandwichId);

            builder.HasData(new Sandwich
            {
                Id = 1,
                Name = "XBurger",
                Price = 5.00m,
                Userid = new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E")
            });

            builder.HasData(new Sandwich
            {
                Id = 2,
                Name = "XEgg",
                Price = 4.50m,
                Userid = new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E")
            });

            builder.HasData(new Sandwich
            {
                Id = 3,
                Name = "XBacon",
                Price = 7.00m,
                Userid = new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E")
            });

        }
    }
}