using System;

namespace PricingSystem.Utilities
{
    public class CalculationHelper
    {
        public static decimal Round(decimal value)
        {
            return Math.Round(value, 2);
        }
    }
}
