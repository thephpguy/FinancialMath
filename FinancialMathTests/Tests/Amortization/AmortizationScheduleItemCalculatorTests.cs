namespace FinancialMath.Amortization.Tests;

using FinancialMath.Amortization.Models;
using FinancialMath.Core.Amortization;

using Xunit;

public class AmortizationScheduleItemCalculatorTests
{
    [Fact]
    public void CalculateAmortizationScheduleItem_FirstPayment_ReturnsCorrectScheduleItem()
    {
        // Arrange
        LoanTerms loanTerms = LoanTerms.Create(
            loanAmount: 1000m,
            interestRate: 5.0m,     // 5% annual interest rate
            loanTermMonths: 12,     // 1 year (12 months)
            roundingPrecision: 2
        );

        decimal remainingBalance = 1000;
        decimal monthlyPayment = 85.61m;
        int paymentNumber = 1;

        // Act
        AmortizationScheduleItem amortizationScheduleItem = new();
        AmortizationScheduleItemCalculator amortizationScheduleItemCalculator = new(amortizationScheduleItem);

        AmortizationScheduleItem asi = (AmortizationScheduleItem)amortizationScheduleItemCalculator.CalculateAmortizationScheduleItem(loanTerms, remainingBalance, monthlyPayment, loanTerms.MonthlyInterestRate, paymentNumber);

        // Assert
        Assert.Equal(4.17m, asi.Interest);
        Assert.Equal(81.44m, asi.Principal);
        Assert.Equal(918.56m, asi.Balance);
        Assert.Equal(1, asi.PaymentNumber);
    }

    [Fact]
    public void CalculateAmortizationScheduleItem_LastPayment_ReturnsCorrectScheduleItem()
    {
        // Arrange
        LoanTerms loanTerms = LoanTerms.Create(
            loanAmount: 1000m,
            interestRate: 5.0m,     // 5% annual interest rate
            loanTermMonths: 12,     // 1 year (12 months)
            roundingPrecision: 2
        );

        decimal remainingBalance = 85.25m;
        decimal monthlyPayment = 85.61m;
        int paymentNumber = 12;

        // Act
        AmortizationScheduleItem amortizationScheduleItem = new();
        AmortizationScheduleItemCalculator amortizationScheduleItemCalculator = new(amortizationScheduleItem);

        AmortizationScheduleItem asi = (AmortizationScheduleItem)amortizationScheduleItemCalculator.CalculateAmortizationScheduleItem(loanTerms, remainingBalance, monthlyPayment, loanTerms.MonthlyInterestRate, paymentNumber);

        // Assert
        Assert.Equal(.36m, asi.Interest);
        Assert.Equal(85.25m, asi.Principal);
        Assert.Equal(0m, asi.Balance);
        Assert.Equal(12, asi.PaymentNumber);
    }
}
