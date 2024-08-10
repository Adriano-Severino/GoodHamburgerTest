namespace GoodHamburger.Core.Requests.Ordes
{
    /// <summary>
    /// Resquet de deletar o pedido.
    /// </summary>
    public class DeleteOrderRequest : Request
    {
        /// <summary>
        /// Indentificação do pedido.
        /// </summary>
        public long Id { get; set; }
    }
}
