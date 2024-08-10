using GoodHamburger.Api.Data;
using GoodHamburger.Api.Repository;
using GoodHamburger.Core.Handlers;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Repository;
using GoodHamburger.Core.Requests.Extras;
using GoodHamburger.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Api.Handlers
{
    public class ExtraHandler(IExtraRepository _extraRepository) : IExtraHandler
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os extras.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Extra>?>> GetAllAsync(GetAllExtrasRequest request)
        {
            var result = await _extraRepository.GetAllAsync(request);
            if (result is not null)
            {
                var count = result.Count;
                return new PagedResponse<List<Extra>?>(result, count, request.PageNumber, request.PageSize);
            }

            return new PagedResponse<List<Extra>?>(result, request.PageNumber, request.PageSize);

        }

        /// <summary>
        /// Metodo responsavel por criar um extra.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Extra?>> CreateAsync(CreateExtraRequest request)
        {
            var extra = new Extra();
            extra.Userid = request.Userid;
            extra.Name = request.Name;
            extra.Price = request.Price;

            if (request.Name.ToLower() != "fries" && request.Name.ToLower() != "softdrink")
                return new Response<Extra?>(null, 500, "Voce so pode escolher Fries, SoftDrink.");

            try
            {
                await _extraRepository.CreateAsync(extra);
                return new Response<Extra?>(extra, 201, "Extra criada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Extra?>(null, 500, "Não foi possive criar o extra");
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar um extra por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Extra?>> GetByIdAsync(GetExtraByIdRequest request)
        {
            var order = await _extraRepository.GetByIdAsync(request);

            return order is null
                ? new Response<Extra?>(null, 404, "Extra não encontrado")
                : new Response<Extra?>(order);
        }

        /// <summary>
        /// Metodo responsavel por atualizar um extra
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Extra?>> UpdateAsync(UpdateExtraRequest request)
        {
            var getExtraByIdRequest = new GetExtraByIdRequest();
            getExtraByIdRequest.Id = request.Id;

            var result = await GetByIdAsync(getExtraByIdRequest);

            if (result.Data is null)
                return new Response<Extra?>(null, 404, "O pedido não encontrado");

            var extra = result.Data as Extra;
            extra.Userid = request.Userid;
            extra.Name = request.Name;
            extra.Price = request.Price;

            try
            {
                await _extraRepository.UpdateAsync(extra);
                return new Response<Extra?>(extra, message: "Extra atualizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Extra?>(null, 500, "Não foi possive atualizar o extra");
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar um extra.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Extra?>> DeleteAsync(DeleteExtraRequest request)
        {
            var getExtraByIdRequest = new GetExtraByIdRequest();
            getExtraByIdRequest.Id = request.Id;
            var result = await GetByIdAsync(getExtraByIdRequest);

            if (result.Data is null)
                return new Response<Extra?>(null, 404, "O extra não encontrado");

            var extra = result.Data as Extra;
            try
            {
                await _extraRepository.DeleteAsync(extra);
                return new Response<Extra?>(extra, message: "Extra deletada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Extra?>(null, 500, "Não foi possivel deletar o extra");
            }
        }
    }
}
