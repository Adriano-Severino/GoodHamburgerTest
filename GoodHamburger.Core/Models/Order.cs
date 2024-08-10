namespace GoodHamburger.Core.Models
{
    public class Order
    {
        public long Id { get; set; }
        public Guid Userid { get; set; }
        private const decimal DiscountTakesAll = 0.20m;
        private const decimal DiscountSandwichDrink = 0.15m;
        private const decimal DiscountSandwichFries = 0.20m;
        public Sandwich Sandwich { get; set; }
        public decimal TotalPrice
        {
            get
            {
                var discount = CalculateDiscount();
                var sandwichPrice = Sandwich?.Price ?? 0;
                var extrasPrice = Sandwich.Extra?.Sum(extra => extra.Price) ?? 0;
                return (sandwichPrice + extrasPrice) * (1 - discount);
            }
        }
        private decimal CalculateDiscount()
        {
            var softDrink = Sandwich.Extra.Where(x => x.Name.ToLower() == "SoftDrink".ToLower());
            var fries = Sandwich.Extra.Where(x => x.Name.ToLower() == "Fries".ToLower());

            if (Sandwich != null && Sandwich.Extra != null)
            {
                if (Sandwich.Extra.Count >= 2)
                {
                    return DiscountTakesAll;
                }
                else if (softDrink.Count() == 1)
                {
                    return DiscountSandwichDrink;
                }
                else if (fries.Count() == 1)
                {
                    return DiscountSandwichFries;
                }
            }
            return 0m;
        }
    }
}
