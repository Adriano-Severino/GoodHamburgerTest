namespace GoodHamburger.Core.Requests.Ordes
{
    /// <summary>
    /// Request para buscar todos os pedidos.
    /// </summary>
    public class GetAllOrderRequest : PagedRequest
    {
        /// <summary>
        /// Indentificação do usuario.
        /// </summary>
        public Guid Userid { get; set; }
    }
}
