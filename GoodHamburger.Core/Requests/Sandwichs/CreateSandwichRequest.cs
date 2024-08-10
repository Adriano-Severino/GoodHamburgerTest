using GoodHamburger.Core.Models;

namespace GoodHamburger.Core.Requests.Sandwichs
{
    /// <summary>
    /// Requisição de criação do Sandwich.
    /// </summary>
    public class CreateSandwichRequest : Request
    {
        /// <summary>
        /// Nome do Sandwich.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Preço do Sandwich.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Lista de extras.
        /// </summary>
        public IList<Extra> Extra { get; set; } = new List<Extra>();
    }
}
