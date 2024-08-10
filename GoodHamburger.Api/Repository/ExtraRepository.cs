using GoodHamburger.Api.Data;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Repository;
using GoodHamburger.Core.Requests.Extras;
using GoodHamburger.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Api.Repository
{
    /// <summary>
    /// Repositorio do extra.
    /// </summary>
    /// <param name="context"></param>
    public class ExtraRepository(AppDbContext context) : IExtraRepository
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os extras.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<Extra>?> GetAllAsync(GetAllExtrasRequest request)
        {
            var query =
                context.Extras
                    .AsTracking();

            var extras = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .ToListAsync();

            return extras;
        }

        /// <summary>
        /// Metodo responsavel por criar um extra.
        /// </summary>
        /// <param name="extra"></param>
        /// <returns></returns>
        public async Task<Extra?> CreateAsync(Extra extra)
        {
            await context.Extras.AddAsync(extra);
            await context.SaveChangesAsync();
            return extra;
        }

        /// <summary>
        /// Metodo responsavel por buscar um extra por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Extra?> GetByIdAsync(GetExtraByIdRequest request)
        {
            return await context.Extras.AsTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        }

        /// <summary>
        /// Metodo responsavel por atualizar um extra
        /// </summary>
        /// <param name="extra"></param>
        /// <returns></returns>
        public async Task<Extra?> UpdateAsync(Extra extra)
        {
            context.Extras.Update(extra);
            await context.SaveChangesAsync();
            return extra;
        }

        /// <summary>
        /// Metodo responsavel por deletar um extra.
        /// </summary>
        /// <param name="extra"></param>
        /// <returns></returns>
        public async Task<Extra?> DeleteAsync(Extra extra)
        {
            context.Extras.Remove(extra);
            await context.SaveChangesAsync();
            return extra;
        }
    }
}
