using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Extras;
using GoodHamburger.Core.Responses;

namespace GoodHamburger.Core.Handlers
{
    /// <summary>
    /// Interface do extra.
    /// </summary>
    public interface IExtraHandler
    {
        /// <summary>
        /// Metodo de criar um extra.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Extra?>> CreateAsync(CreateExtraRequest request);

        /// <summary>
        /// Metodo de atualizar um extra.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Extra?>> UpdateAsync(UpdateExtraRequest request);

        /// <summary>
        /// Metoto de deletar um extra.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Extra?>> DeleteAsync(DeleteExtraRequest request);

        /// <summary>
        /// Metodo de buscar um extra por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Extra?>> GetByIdAsync(GetExtraByIdRequest request);

        /// <summary>
        /// Metodo de buscar todos os extras.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResponse<List<Extra>?>> GetAllAsync(GetAllExtrasRequest request);
    }
}
