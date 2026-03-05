using PricingSystem.Services.Interfaces;

namespace PricingSystem.Services
{
    public class TaxService : ITaxService
    {
        public decimal GetTaxRate(string country)
        {
            return country switch
            {
                "MK" => 0.18m,
                "DE" => 0.20m,
                "FR" => 0.20m,
                "USA" => 0.10m,
                _ => 0.20m
            };
        }

        public decimal CalculateTaxAmount(decimal subtotal, decimal taxRate)
        {
            return subtotal * taxRate;
        }
    }
}
