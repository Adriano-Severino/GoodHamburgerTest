namespace GoodHamburger.Core.Models
{
    public class Sandwich
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
        /// Propiedade de navegação do Sandwich.
        /// </summary>
        public IList<Extra> Extra { get; set; } = new List<Extra>();
    }
}
