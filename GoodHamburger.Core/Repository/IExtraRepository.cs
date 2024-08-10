using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Extras;
using GoodHamburger.Core.Responses;

namespace GoodHamburger.Core.Repository
{
    /// <summary>
    /// Interface extra.
    /// </summary>
    public interface IExtraRepository
    {
        /// <summary>
        /// Metodo de criar um extra.
        /// </summary>
        /// <param name="extra"></param>
        /// <returns></returns>
        Task<Extra?> CreateAsync(Extra extra);

        /// <summary>
        /// Metodo de atualizar um extra.
        /// </summary>
        /// <param name="extra"></param>
        /// <returns></returns>
        Task<Extra?> UpdateAsync(Extra extra);

        /// <summary>
        /// Metoto de deletar um extra.
        /// </summary>
        /// <param name="extra"></param>
        /// <returns></returns>
        Task<Extra?> DeleteAsync(Extra extra);

        /// <summary>
        /// Metodo de buscar um extra por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Extra?> GetByIdAsync(GetExtraByIdRequest request);

        /// <summary>
        /// Metodo de buscar todos os extras.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<Extra>?> GetAllAsync(GetAllExtrasRequest request);
    }
}
