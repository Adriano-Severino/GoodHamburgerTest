namespace GoodHamburger.Core.Requests.Extras
{
    /// <summary>
    /// Requisição de criação do extra.
    /// </summary>
    public class CreateExtraRequest : Request
    {
        /// <summary>
        /// Nome do extra.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Preço do extra.
        /// </summary>
        public decimal Price { get; set; }
    }
}
