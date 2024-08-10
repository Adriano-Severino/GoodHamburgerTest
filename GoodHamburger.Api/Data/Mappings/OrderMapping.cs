using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoodHamburger.Core.Models;

namespace GoodHamburger.Api.Data.Mappings
{
    /// <summary>
    /// Mapeamento da tabela de pedido.
    /// </summary>
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configuração do mapeamento.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(x => x.Id);

        }
    }
}
