using PricingSystem.DTOs;
using PricingSystem.Services.Interfaces;
using PricingSystem.Utilities;
using System;

namespace PricingSystem.Services
{
    public class PricingService : IPricingService
    {

        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;
        private readonly ITaxService _taxService;


        public PricingService(IProductService productService, 
            IDiscountService discountService,
            ITaxService taxService)
        {
            _productService = productService;
            _discountService = discountService;
            _taxService = taxService;
        }


        public PricingResponse CalculatePrice(OrderRequest request)
        {
            var product = _productService.GetProduct(request.ProductId);

            if (product == null)
                throw new Exception($"Product {request.ProductId} not found");


            // Calculate subtotal
            decimal subtotal = CalculateSubtotal(request.Quantity, product.Price);

            // Calculate discount
            decimal discountPct = _discountService.CalculateDiscount(request.Quantity, subtotal);
            decimal discountAmount = _discountService.CalculateDiscountAmount(subtotal, discountPct);

            // Subtotal after discount
            decimal subtotalAfterDiscount = subtotal - discountAmount;

            // Calculate tax
            decimal taxRate = _taxService.GetTaxRate(request.Country);
            decimal taxAmount = _taxService.CalculateTaxAmount(subtotalAfterDiscount, taxRate);
          

            decimal finalPrice = CalculationHelper.Round(subtotalAfterDiscount + taxAmount);

            return new PricingResponse
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = request.Quantity,
                UnitPrice = product.Price,
                Country = request.Country,

                Subtotal = subtotal,

                Discount = new DiscountResponse
                {
                    Percentage = discountPct,
                    Amount = CalculationHelper.Round(discountAmount)
                },

                SubtotalAfterDiscount = CalculationHelper.Round(subtotal - discountAmount),

                Tax = new TaxResponse
                {
                    Country = request.Country,
                    Rate = taxRate,
                    Amount = CalculationHelper.Round(taxAmount)
                },

                FinalPrice = finalPrice
            };
        }

        public decimal CalculateSubtotal(int quantity, decimal unitPrice)
        {
                return quantity * unitPrice;
        }
    }

}
