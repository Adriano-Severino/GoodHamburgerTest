using GoodHamburger.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace GoodHamburger.Core.Requests.Ordes
{
    /// <summary>
    /// Request de criaçao do Sandwich.
    /// </summary>
    public class CreateOrderRequest : Request
    {
        /// <summary>
        /// Sandwich
        /// </summary>
        [Required(ErrorMessage = "O tipo de sanduíche não é válido")]
        public Sandwich Sandwich { get; set; }

    }
}
