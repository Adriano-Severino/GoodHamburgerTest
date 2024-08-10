namespace GoodHamburger.Core.Requests.Extras
{
    /// <summary>
    /// Requisição para buscar lumianria por id.
    /// </summary>
    public class GetExtraByIdRequest : Request
    {
        /// <summary>
        /// Identificação da luminaria.
        /// </summary>
        public long Id { get; set; }
    }
}
