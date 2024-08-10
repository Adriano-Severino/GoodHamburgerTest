using GoodHamburger.Api.Data;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Repository;
using GoodHamburger.Core.Requests.Ordes;
using GoodHamburger.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Api.Repository
{
    /// <summary>
    /// Repositorio do pedido.
    /// </summary>
    /// <param name="context"></param>
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os pedidos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<Order>?> GetAllAsync(GetAllOrderRequest request)
        {
            var query =
                context.Orders
                    .Include(x => x.Sandwich)
                    .ThenInclude(extra => extra.Extra)
                    .AsTracking();

            var ordes = await query
                    .Skip(request.Skip)
                    .Take(request.PageSize)
                    .ToListAsync();
            
            return ordes;
        }

        /// <summary>
        /// Metodo responsavel por criar um pedido.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order?> CreateAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Metodo responsavel por buscar um pedido por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Order?> GetByIdAsync(GetOrderByIdRequest request)
        {
            var orderResult =
           await context.Orders
               .Include(x => x.Sandwich)
               .ThenInclude(extra => extra.Extra)
               .AsTracking()
               .FirstOrDefaultAsync(x => x.Id == request.Id);

            return orderResult;
        }

        /// <summary>
        /// Metodo responsavel por atualizar um pedido
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order?> UpdateAsync(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Metodo responsavel por deletar um pedido.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order?> DeleteAsync(Order order)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
            return order;
        }
    }
}
