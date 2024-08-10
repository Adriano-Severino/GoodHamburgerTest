using GoodHamburger.Api.Data;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Repository;
using GoodHamburger.Core.Requests.Sandwichs;
using GoodHamburger.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Api.Repository
{
    /// <summary>
    /// Repositorio do Sandwich.
    /// </summary>
    /// <param name="context"></param>
    public class SandwichRepository(AppDbContext context) : ISandwichRepository
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os Sandwichs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<Sandwich>?> GetAllAsync(GetAllSandwichsRequest request)
        {
            var query =
                context.Sandwichs
                    .AsTracking();

            var sandwichs = await query
                    .Skip(request.Skip)
                    .Take(request.PageSize)
                    .ToListAsync();


            return sandwichs;
        }

        /// <summary>
        /// Metodo responsavel por criar um sandwich.
        /// </summary>
        /// <param name="sandwich"></param>
        /// <returns></returns>
        public async Task<Sandwich?> CreateAsync(Sandwich sandwich)
        {
            await context.Sandwichs.AddAsync(sandwich);
            await context.SaveChangesAsync();
            return sandwich;
        }

        /// <summary>
        /// Metodo responsavel por buscar um sandwich por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Sandwich?> GetByIdAsync(GetSandwichByIdRequest request)
        {
            var sandwich =
           await context.Sandwichs
               .AsTracking()
               .FirstOrDefaultAsync(x => x.Id == request.Id);

            return sandwich;
        }

        /// <summary>
        /// Metodo responsavel por atualizar um sandwich
        /// </summary>
        /// <param name="sandwich"></param>
        /// <returns></returns>
        public async Task<Sandwich?> UpdateAsync(Sandwich sandwich)
        {
            context.Sandwichs.Update(sandwich);
            await context.SaveChangesAsync();
            return sandwich;
        }

        /// <summary>
        /// Metodo responsavel por deletar um sandwich.
        /// </summary>
        /// <param name="sandwich"></param>
        /// <returns></returns>
        public async Task<Sandwich?> DeleteAsync(Sandwich sandwich)
        {
            context.Sandwichs.Remove(sandwich);
            await context.SaveChangesAsync();
            return sandwich;
        }
    }
}
