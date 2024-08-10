using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Sandwichs;
using GoodHamburger.Core.Responses;

namespace GoodHamburger.Core.Repository
{
    /// <summary>
    /// Interface do Sandwich.
    /// </summary>
    public interface ISandwichRepository
    {
        /// <summary>
        /// Metodo para criar um Sandwich.
        /// </summary>
        /// <param name="sandwich"></param>
        /// <returns></returns>
        Task<Sandwich?> CreateAsync(Sandwich sandwich);

        /// <summary>
        /// metodo para atualizar um Sandwich.
        /// </summary>
        /// <param name="sandwich"></param>
        /// <returns></returns>
        Task<Sandwich?> UpdateAsync(Sandwich sandwich);

        /// <summary>
        /// Metodo para deletar um Sandwich.
        /// </summary>
        /// <param name="sandwich"></param>
        /// <returns></returns>
        Task<Sandwich?> DeleteAsync(Sandwich sandwich);

        /// <summary>
        /// Metodo para buscar um Sandwich por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Sandwich?> GetByIdAsync(GetSandwichByIdRequest request);

        /// <summary>
        /// Metodo para buscar todos os Sandwichs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<Sandwich>?> GetAllAsync(GetAllSandwichsRequest request);
    }
}
