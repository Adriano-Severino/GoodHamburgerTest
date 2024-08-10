namespace GoodHamburger.Core.Requests.Extras
{
    /// <summary>
    /// Requisição de atualização do extra.
    /// </summary>
    public class UpdateExtraRequest : Request
    {
        /// <summary>
        /// Identificação do extra.
        /// </summary>
        public long Id { get; set; }

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
