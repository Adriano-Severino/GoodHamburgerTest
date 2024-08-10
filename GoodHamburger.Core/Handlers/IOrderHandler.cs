using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Ordes;
using GoodHamburger.Core.Responses;

namespace GoodHamburger.Core.Handlers
{
    /// <summary>
    /// Interface do pedido
    /// </summary>
    public interface IOrderHandler
    {
        /// <summary>
        /// Metodo de criar um pedido.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Order?>> CreateAsync(CreateOrderRequest request);

        /// <summary>
        /// Metodo de atualizar um pedido
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Order?>> UpdateAsync(UpdateOrderRequest request);

        /// <summary>
        /// Metodo de deletar um pedido.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Order?>> DeleteAsync(DeleteOrderRequest request);

        /// <summary>
        /// Metodo de buscar um pedido por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<Order?>> GetByIdAsync(GetOrderByIdRequest request);

        /// <summary>
        /// Meotdo de buscar todos os pedidos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrderRequest request);
    }
}
