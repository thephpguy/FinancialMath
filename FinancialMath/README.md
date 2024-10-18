# FinancialMath
Written to be used in a .NET Core application, this library is designed to provide a set of financial calculations that are commonly used in the financial industry.

Highly customizable and extendable this library allows you to inject your own implementations of the various calculators to allow for custom behavior.

## Features
- Amortization
  - Schedule
  - Payment

## Usage

#### Quick and easy method to calculate an amortization schedule:
```csharp
// using FinancialMath;

// Arrange
LoanTerms loanTerms = LoanTerms.Create(
    loanAmount: 100000m,    // Starting Principal of $100,000
    interestRate: .05m,     // 5% annual interest rate
    loanTermMonths: 360,    // 30 years (360 months)
    roundingPrecision: 2    // Round results (payments and interest each month) to the nearest cent IE 2 decimal places.
);

IAmortizationSchedule result = AmortizationScheduleProvider.GetAmortizationSchedule(loanTerms);

```

#### More advanced usage, allowing for custom implementations through dependency injection:

```csharp
// using FinancialMath;

// Amortization Schedule Example
LoanTerms loanTerms = LoanTerms.Create(
    loanAmount: 152000m,     // Starting Principal of $152,000
    interestRate: .03375m,    // 3.375% annual interest rate
    loanTermMonths: 180,     // 15 years (180 months)
    roundingPrecision: 2,    // Round to the nearest cent
    paymentRoundingMethod: MidpointRounding.ToPositiveInfinity
);

// Setup Dependencies To Inject
AmortizationSchedule amortizationSchedule = new();
AmortizationScheduleItem amortizationScheduleItem = new();
AmortizationScheduleItemCalculator amortizationScheduleItemCalculator = new(amortizationScheduleItem);
AmortizationPaymentCalculator amortizationPaymentCalculator = new();

// Get our amortization schedule:
AmortizationScheduleCalculator amortizationScheduleCalculator = new(amortizationSchedule, amortizationScheduleItemCalculator, amortizationPaymentCalculator);

AmortizationSchedule result = (AmortizationSchedule)amortizationScheduleCalculator.GetAmortizationSchedule(loanTerms);
```

## Notes:

Interest rates will always be in decimal form.
 - For example, 3.375% would be represented as .03375.
