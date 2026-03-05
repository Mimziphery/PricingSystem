# PricingApp
Simple pricing app built using ASP.NET Core 3.1

## Description
Simple ASP.NET Core pricing API that calculates:
- Subtotal
- Discount
- Tax
- Final price

## How to Run

Navigate to project folder and run:
- dotnet run

## API Endpoint

### GET Pricing Calculation

| Parameter | Description |
|---|---|
| productId | Product identifier |
| quantity | Order quantity |
| country | Country code |

/api/pricing/calculate?productId=PROD-001&quantity=55&country=MK


/api/pricing/calculate

## Test Cases Results

### Test Case 1
Input:

productId=PROD-001
quantity=55
country=MK


Final Price:

700.92


### Test Case 2
Input:

productId=PROD-001
quantity=100
country=DE


Final Price:

1224.00


### Test Case 3
Input:

productId=PROD-001
quantity=25
country=USA


Final Price:

330.00


## Bugs Fixed

# Interface Implementation Issues
Fixed missing interface implementations for services.


# Discount Calculation Logic
Fixed discount priority logic using ordered conditions:
- 10+ quantity → 5%
- 50+ quantity → 10%
- 100 quantity → 15%

Also ensured:
- No discount applied if subtotal < 500 EUR.
- Also ensured discount is applied before tax calculation.

# Null Validation
Added validation for:
- Missing products

## Author
Mimoza Mickoska