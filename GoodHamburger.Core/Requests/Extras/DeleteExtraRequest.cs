namespace GoodHamburger.Core.Requests.Extras
{
    /// <summary>
    /// Requisição de deletar um extra.
    /// </summary>
    public class DeleteExtraRequest : Request
    {
        /// <summary>
        /// Identificação do extra
        /// </summary>
        public long Id { get; set; }
    }
}
