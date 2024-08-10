namespace GoodHamburger.Core.Models
{
    public class Extra
    {
        /// <summary>
        /// Identificação do Extra.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Identificação do Sandwich.
        /// </summary>
        public long? SandwichId { get; set; }

        /// <summary>
        /// Identificação do usuario.
        /// </summary>
        public Guid Userid { get; set; }

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
