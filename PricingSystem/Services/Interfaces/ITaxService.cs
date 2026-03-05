namespace PricingSystem.Services.Interfaces
{
    public interface ITaxService
    {
        decimal GetTaxRate(string country);
        decimal CalculateTaxAmount(decimal subtotal, decimal taxRate);
    }
}
