using GoodHamburger.Api.Data;
using GoodHamburger.Api.Repository;
using GoodHamburger.Core.Handlers;
using GoodHamburger.Core.Models;
using GoodHamburger.Core.Repository;
using GoodHamburger.Core.Requests.Ordes;
using GoodHamburger.Core.Requests.Sandwichs;
using GoodHamburger.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Api.Handlers
{
    public class SandwichHandler(ISandwichRepository _sandwichRepository) : ISandwichHandler
    {
        /// <summary>
        /// Metodo responsavel por buscar todos os Sandwichs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<Sandwich>?>> GetAllAsync(GetAllSandwichsRequest request)
        {
            var result = await _sandwichRepository.GetAllAsync(request);
            if (result is not null)
            {
                var count = result.Count;
                return new PagedResponse<List<Sandwich>?>(result, count, request.PageNumber, request.PageSize);
            }

            return new PagedResponse<List<Sandwich>?>(result, request.PageNumber, request.PageSize);
        }

        /// <summary>
        /// Metodo responsavel por criar um sandwich.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Sandwich?>> CreateAsync(CreateSandwichRequest request)
        {
            var sandwich = new Sandwich();
            sandwich.Userid = request.Userid;
            sandwich.Name = request.Name;
            sandwich.Price = request.Price;

            if (request.Name.ToLower() != "xburger" && request.Name.ToLower() != "xegg" && request.Name.ToLower() != "xbacon")
                return new Response<Sandwich?>(null, 500, "Voce so pode escolher XBurger, XEgg, XBacon.");

            var fries = request.Extra.Where(x => x.Name.ToLower() == "fries").ToList();
            var softdrink = request.Extra.Where(x => x.Name.ToLower() == "softdrink").ToList();

            if (fries.Count() > 1)
                return new Response<Sandwich?>(null, 500, "Voce so pode adicionar 1 Fries como extra.");

            if (softdrink.Count() > 1)
                return new Response<Sandwich?>(null, 500, "Voce so pode adicionar 1 SoftDrink como extra.");

            if (request.Extra.Any(x => x.Name.ToLower() != "fries") && request.Extra.Any(x => x.Name.ToLower() != "softdrink"))
            {
                return new Response<Sandwich?>(null, 500, "Voce so pode adicionar Fries ou SoftDrink ou ambos.");
            }

            try
            {
                await _sandwichRepository.CreateAsync(sandwich);
                return new Response<Sandwich?>(sandwich, 201, "Sandwich criada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Sandwich?>(null, 500, "Não foi possive criar o Sandwich");
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar um sandwich por id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Sandwich?>> GetByIdAsync(GetSandwichByIdRequest request)
        {
            var sandwich = await _sandwichRepository.GetByIdAsync(request);

            return sandwich is null
                ? new Response<Sandwich?>(null, 404, "Sandwich não encontrado")
                : new Response<Sandwich?>(sandwich);
        }

        /// <summary>
        /// Metodo responsavel por atualizar um sandwich
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Sandwich?>> UpdateAsync(UpdateSandwichRequest request)
        {
            var getSandwichByIdRequest = new GetSandwichByIdRequest();
            getSandwichByIdRequest.Id = request.Id;

            var result = await GetByIdAsync(getSandwichByIdRequest);

            if (result.Data is null)
                return new Response<Sandwich?>(null, 404, "O sandwich não encontrado");

            var sandwich = result.Data as Sandwich;

            sandwich.Userid = request.Userid;
            sandwich.Name = request.Name;
            sandwich.Price = request.Price;
            sandwich.Extra = request.Extra;

            try
            {
                await _sandwichRepository.UpdateAsync(sandwich);
                return new Response<Sandwich?>(sandwich, message: "Sandwich atualizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Sandwich?>(null, 500, "Não foi possive atualizar o sandwich");
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar um sandwich.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Sandwich?>> DeleteAsync(DeleteSandwichRequest request)
        {

            var getSandwichByIdRequest = new GetSandwichByIdRequest();
            getSandwichByIdRequest.Id = request.Id;

            var result = await GetByIdAsync(getSandwichByIdRequest);

            if (result.Data is null)
                return new Response<Sandwich?>(null, 404, "O sandwich não encontrado");

            var sandwich = result.Data as Sandwich;
            try
            {
                await _sandwichRepository.DeleteAsync(sandwich);
                return new Response<Sandwich?>(sandwich, message: "sandwich deletada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Sandwich?>(null, 500, "Não foi possivel deletar o sandwich");
            }
        }
    }
}
