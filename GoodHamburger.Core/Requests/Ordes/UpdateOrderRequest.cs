using GoodHamburger.Core.Models;

namespace GoodHamburger.Core.Requests.Ordes
{
    /// <summary>
    /// Resquet de atualização do pedido.
    /// </summary>
    public class UpdateOrderRequest : Request
    {
        /// <summary>
        /// Indentificação do pedido.
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// Sandwich
        /// </summary>
        public Sandwich Sandwich { get; set; }
    }
}
