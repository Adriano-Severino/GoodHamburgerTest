using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Ordes;
using GoodHamburger.Core.Responses;

namespace GoodHamburger.Core.Repository
{
    /// <summary>
    /// Interface do pedido.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Metodo de criar um pedido.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order?> CreateAsync(Order order);

        /// <summary>
        /// Metodo de atualizar um pedido
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order?> UpdateAsync(Order order);

        /// <summary>
        /// Metodo de deletar um pedido.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order?> DeleteAsync(Order order);

        /// <summary>
        /// Metodo de buscar um pedido por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Order?> GetByIdAsync(GetOrderByIdRequest request);

        /// <summary>
        /// Meotdo de buscar todos os pedidos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<Order>?> GetAllAsync(GetAllOrderRequest request);
    }
}
