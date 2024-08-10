using GoodHamburger.Api.Data;
using GoodHamburger.Api.Repository;
using GoodHamburger.Core.Handlers;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Repository;
using GoodHamburger.Core.Requests.Extras;
using GoodHamburger.Core.Requests.Ordes;
using GoodHamburger.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Api.Handlers
{
    /// <summary>
    /// Serviço de Pedidos.
    /// </summary>
    /// <param name="context"></param>
    public class OrderHandler(IOrderRepository _orderRepository) : IOrderHandler
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os pedidos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrderRequest request)
        {
            var result = await _orderRepository.GetAllAsync(request);
            if (result is not null)
            {
                var count = result.Count;
                return new PagedResponse<List<Order>?>(result, count, request.PageNumber, request.PageSize);
            }

            return new PagedResponse<List<Order>?>(result, request.PageNumber, request.PageSize);
        }

        /// <summary>
        /// Metodo responsavel por criar um pedido.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Order?>> CreateAsync(CreateOrderRequest request)
        {
            var order = new Order();
            order.Userid = request.Userid;

            if (request.Sandwich.Name.ToLower() != "xburger" && request.Sandwich.Name.ToLower() != "xegg" && request.Sandwich.Name.ToLower() != "xbacon")
                return new Response<Order?>(null, 500, "Voce so pode escolher XBurger, XEgg, XBacon.");

            var fries = request.Sandwich.Extra.Where(x => x.Name.ToLower() == "fries").ToList();
            var softdrink = request.Sandwich.Extra.Where(x => x.Name.ToLower() == "softdrink").ToList();

            if (fries.Count() > 1)
                return new Response<Order?>(null, 500, "Voce so pode adicionar 1 Fries como extra.");

            if (softdrink.Count() > 1)
                return new Response<Order?>(null, 500, "Voce so pode adicionar 1 SoftDrink como extra.");

            if (request.Sandwich.Extra.Any(x => x.Name.ToLower() != "fries") && request.Sandwich.Extra.Any(x => x.Name.ToLower() != "softdrink"))
            {
                return new Response<Order?>(null, 500, "Voce so pode adicionar Fries ou SoftDrink ou ambos.");
            }

            order.Sandwich = request.Sandwich;

            try
            {
                await _orderRepository.UpdateAsync(order);
                return new Response<Order?>(order, 201, "Pedido criada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Order?>(null, 500, "Não foi possive criar o pedido");
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar um pedido por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Order?>> GetByIdAsync(GetOrderByIdRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(request);

            return order is null
                ? new Response<Order?>(null, 404, "O pedido não encontrado")
                : new Response<Order?>(order);
        }

        /// <summary>
        /// Metodo responsavel por atualizar um pedido
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Order?>> UpdateAsync(UpdateOrderRequest request)
        {
            var getOrderByIdRequest = new GetOrderByIdRequest();
            getOrderByIdRequest.Id = request.Id;

            var result = await GetByIdAsync(getOrderByIdRequest);

            if (result.Data is null)
                return new Response<Order?>(null, 404, "O pedido não encontrado");

            var order = result.Data as Order;
            order.Sandwich = request.Sandwich;
            try
            {
                await _orderRepository.UpdateAsync(order);
                return new Response<Order?>(order, message: "Order atualizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Order?>(null, 500, "Não foi possive atualizar o pedido");
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar um pedido.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Order?>> DeleteAsync(DeleteOrderRequest request)
        {
            var getOrderByIdRequest = new GetOrderByIdRequest();
            getOrderByIdRequest.Id = request.Id;
            var result = await GetByIdAsync(getOrderByIdRequest);

            if (result.Data is null)
                return new Response<Order?>(null, 404, "O pedido não encontrado");

            var order = result.Data as Order;
            try
            {
                await _orderRepository.DeleteAsync(order);
                return new Response<Order?>(order, message: "Pedido deletada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Order?>(null, 500, "Não foi possivel deletar o pedido");
            }
        }
    }
}