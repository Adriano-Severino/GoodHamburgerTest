namespace GoodHamburger.Core.Requests.Sandwichs
{
    /// <summary>
    /// Requisição de deletar um Sandwich.
    /// </summary>
    public class DeleteSandwichRequest : Request
    {
        /// <summary>
        /// Identificação do Sandwich
        /// </summary>
        public long Id { get; set; }
    }
}
