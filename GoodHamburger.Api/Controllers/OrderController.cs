using GoodHamburger.Core;
using GoodHamburger.Core.Handlers;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Ordes;
using GoodHamburger.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api.Controllers
{
    /// <summary>
    /// Controller responsavel pela requisição do pedido.
    /// </summary>
    /// <param name="handler"></param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController(IOrderHandler handler) : ControllerBase
    {
        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        /// <param name="request">Dados do pedido a ser criado.</param>
        /// <returns>Resposta da criação do pedido.</returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(IResult), 201)]
        [ProducesResponseType(typeof(IResult), 400)]
        public async Task<IResult> CreateAsync(CreateOrderRequest request)
        {
            request.Userid = ApiConfiguration.Userid;
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/pedido/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Busca todos os pedidos.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Resposta da busca de todos os pedidos</returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(PagedResponse<List<Order>>), 200)]
        public async Task<IResult> GetAllAsync(
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllOrderRequest();
            request.Userid = ApiConfiguration.Userid;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;

            var response = await handler.GetAllAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);

        }

        /// <summary>
        /// Buscar o pedido por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Resposta da busca do pedido por id</returns>
        [HttpGet]
        [Route("get-by-id")]
        [ProducesResponseType(typeof(Response<Order>), 200)]
        public async Task<IResult> GetByIdAsync(long id)
        {
            var request = new GetOrderByIdRequest();
            request.Userid = ApiConfiguration.Userid;
            request.Id = id;
            var response = await handler.GetByIdAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Atualiza um pedido.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>Resposta da atualização do pedido</returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(Response<Order>), 200)]
        public async Task<IResult> UpdateAsync(UpdateOrderRequest request, long id)
        {
            request.Userid = ApiConfiguration.Userid;
            request.Id = id;
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Deleta o pedido por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Resposta da exclusão do pedido</returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(Response<Order>), 200)]
        public async Task<IResult> DeleteAsync(long id)
        {
            var request = new DeleteOrderRequest();
            request.Userid = ApiConfiguration.Userid;
            request.Id = id;
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
