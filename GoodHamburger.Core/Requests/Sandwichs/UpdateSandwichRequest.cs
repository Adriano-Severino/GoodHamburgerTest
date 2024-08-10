using GoodHamburger.Core.Models;

namespace GoodHamburger.Core.Requests.Sandwichs
{
    /// <summary>
    /// Requisição de atualização do Sandwich.
    /// </summary>
    public class UpdateSandwichRequest : Request
    {
        /// <summary>
        /// Identificação do Sandwich.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Identificação do usuario.
        /// </summary>
        public Guid Userid { get; set; }

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
