namespace GoodHamburger.Core.Requests.Sandwichs
{
    /// <summary>
    /// Requisição para buscar Sandwich por id.
    /// </summary>
    public class GetSandwichByIdRequest : Request
    {
        /// <summary>
        /// Identificação do Sandwich.
        /// </summary>
        public long Id { get; set; }
    }
}
