using GoodHamburger.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburger.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela do extra.
    /// </summary>
    public class ExtraMapping : IEntityTypeConfiguration<Extra>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Extra> builder)
        {
            builder.ToTable("Extra");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
             .IsRequired(true)
             .HasColumnType("NVARCHAR")
             .HasMaxLength(100);


            builder.HasData(new Extra
            {
                Id = 1,
                Name = "Fries",
                Price = 2.00m,
                Userid = new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E")
            });

            builder.HasData(new Extra
            {
                Id = 2,
                Name = "SoftDrink",
                Price = 2.50m,
                Userid = new Guid("206D0FCC-EA9A-4164-9C38-C48B18451E1E")
            });


        }
    }
}