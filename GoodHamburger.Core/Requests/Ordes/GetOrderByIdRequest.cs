namespace GoodHamburger.Core.Requests.Ordes
{
    /// <summary>
    /// Reqeust para buscar um pedido por id.
    /// </summary>
    public class GetOrderByIdRequest : Request
    {
        /// <summary>
        /// Identificação do pedido.
        /// </summary>
        public long Id { get; set; }
    }
}
