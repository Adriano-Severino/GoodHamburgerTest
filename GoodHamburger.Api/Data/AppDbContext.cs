using GoodHamburger.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GoodHamburger.Api.Data
{
    /// <summary>
    /// SbContext da aplicação.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Contrutor do AppDbContext.
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) :
       base(options)
        { }

        /// <summary>
        /// Gerenciamento da tabela Order.
        /// </summary>
        public DbSet<Order> Orders { get; set; } = null!;

        /// <summary>
        /// Gerenciamento da tabela Extras.
        /// </summary>
        public DbSet<Extra> Extras { get; set; } = null!;

        /// <summary>
        /// Gerenciamento da tabela Sandwich.
        /// </summary>
        public DbSet<Sandwich> Sandwichs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
}
