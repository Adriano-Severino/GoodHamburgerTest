namespace GoodHamburger.Core.Requests.Sandwichs
{
    /// <summary>
    /// Requisição de buscar todos os Sandwich.
    /// </summary>
    public class GetAllSandwichsRequest : PagedRequest
    {
        /// <summary>
        /// Identificação do usuario.
        /// </summary>
        public Guid Userid { get; set; }
    }
}
