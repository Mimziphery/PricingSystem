namespace PricingSystem.DTOs
{
    public class PricingResponse
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Country { get; set; }

        public decimal Subtotal { get; set; }
        public decimal FinalPrice { get; set; }

        public DiscountResponse Discount { get; set; }

        public decimal SubtotalAfterDiscount { get; set; }
        public TaxResponse Tax { get; set; }
    }
}
