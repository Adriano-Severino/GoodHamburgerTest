using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Sandwichs;
using GoodHamburger.Core.Responses;

namespace GoodHamburger.Core.Handlers
{
    /// <summary>
    /// Interface do Sandwich.
    /// </summary>
    public interface ISandwichHandler
    {
        /// <summary>
        /// Metodo para criar um Sandwich.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Sandwich?>> CreateAsync(CreateSandwichRequest request);

        /// <summary>
        /// metodo para atualizar um Sandwich.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Sandwich?>> UpdateAsync(UpdateSandwichRequest request);

        /// <summary>
        /// Metodo para deletar um Sandwich.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Sandwich?>> DeleteAsync(DeleteSandwichRequest request);

        /// <summary>
        /// Metodo para buscar um Sandwich por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Sandwich?>> GetByIdAsync(GetSandwichByIdRequest request);

        /// <summary>
        /// Metodo para buscar todos os Sandwichs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResponse<List<Sandwich>?>> GetAllAsync(GetAllSandwichsRequest request);
    }
}
