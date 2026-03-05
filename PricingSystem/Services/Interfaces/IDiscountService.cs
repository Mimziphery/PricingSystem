namespace PricingSystem.Services.Interfaces
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(int quantity, decimal subtotal);
        decimal CalculateDiscountAmount(decimal subtotal, decimal percent);
    }
}
