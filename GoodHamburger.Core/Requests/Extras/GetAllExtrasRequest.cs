namespace GoodHamburger.Core.Requests.Extras
{
    /// <summary>
    /// Requisição de buscar todas os Sandwichs.
    /// </summary>
    public class GetAllExtrasRequest : PagedRequest
    {
        /// <summary>
        /// Identificação do usuario.
        /// </summary>
        public Guid Userid { get; set; }
    }
}
