using GoodHamburger.Core;
using GoodHamburger.Core.Handlers;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Requests.Sandwichs;
using GoodHamburger.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api.Controllers
{
    /// <summary>
    /// Controller responsavel pela requisição do Sandwich
    /// </summary>
    /// <param name="handler"></param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SandwichController(ISandwichHandler handler) : ControllerBase
    {
        /// <summary>
        /// Cria um Sandwich.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(IResult), 201)]
        [ProducesResponseType(typeof(IResult), 400)]
        public async Task<IResult> CreateAsync(CreateSandwichRequest request)
        {
            request.Userid = ApiConfiguration.Userid;
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/sandwich/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Busca todos os Sandwichs.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Resposa pagina com uma lista de Sandwichs</returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(PagedResponse<List<Sandwich>>), 200)]
        public async Task<IResult> GetAllAsync(
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllSandwichsRequest();
            request.Userid = ApiConfiguration.Userid;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;

            var response = await handler.GetAllAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);

        }

        /// <summary>
        /// Buscar um sandwich por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-by-id")]
        [ProducesResponseType(typeof(Response<Sandwich>), 200)]
        public async Task<IResult> GetByIdAsync(long id)
        {
            var request = new GetSandwichByIdRequest();
            request.Userid = ApiConfiguration.Userid;
            request.Id = id;
            var response = await handler.GetByIdAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Atualiza um sandwich por id.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(Response<Sandwich>), 200)]
        public async Task<IResult> UpdateAsync(UpdateSandwichRequest request, long id)
        {
            request.Userid = ApiConfiguration.Userid;
            request.Id = id;
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }

        /// <summary>
        /// Deleta um sandwich por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(Response<Sandwich>), 200)]
        public async Task<IResult> DeleteAsync(long id)
        {
            var request = new DeleteSandwichRequest();
            request.Userid = ApiConfiguration.Userid;
            request.Id = id;
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
