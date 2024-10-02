namespace FinancialMathTests.Amortization.Tests;

using FinancialMath.Amortization.Models;
using FinancialMath.Core.Amortization;
using FinancialMath.Interfaces;
using Xunit;

public class GetAmortizationScheduleTests
{
    [Fact]
    public void CalculateAmortizedPayment_ValidTerms_ReturnsCorrectAmount()
    {
        // Arrange
        LoanTerms loanTerms = LoanTerms.Create(
            loanAmount: 100000m,
            interestRate: .05m,     // 5% annual interest rate
            loanTermMonths: 360,    // 30 years (360 months)
            roundingPrecision: 2
        );

        AmortizationSchedule expectedSchedule = AmortizationSchedule.Create(
            paymentSchedule: [],
            paymentAmount: 536.83m,
            finalPaymentAmount: 529.72m,
            totalInterestPaid: 93251.69m,
            totalPrincipalPaid: 100000.00m
        );

        // Act
        AmortizationSchedule amortizationSchedule = new();
        AmortizationScheduleItem amortizationScheduleItem = new();
        AmortizationScheduleItemCalculator amortizationScheduleItemCalculator = new(amortizationScheduleItem);
        AmortizationPaymentCalculator amortizationPaymentCalculator = new();

        AmortizationScheduleCalculator amortizationScheduleCalculator = new(amortizationSchedule, amortizationScheduleItemCalculator, amortizationPaymentCalculator);

        IAmortizationSchedule result = amortizationScheduleCalculator.GetAmortizationSchedule(loanTerms);

        // Assert
        Assert.Equal(expectedSchedule.PaymentAmount, result.PaymentAmount);
        Assert.Equal(expectedSchedule.FinalPaymentAmount, result.FinalPaymentAmount);
        Assert.Equal(expectedSchedule.TotalInterestPaid, result.TotalInterestPaid);
        Assert.Equal(expectedSchedule.TotalPrincipalPaid, result.TotalPrincipalPaid);
        Assert.Equal(360, result.PaymentSchedule.Count());
    }


    [Fact]
    public void CalculateAmortizedPaymentWithRoundingToPositiveInfinity_ValidTerms_ReturnsCorrectAmount()
    {
        // Arrange
        LoanTerms loanTerms = LoanTerms.Create(
            loanAmount: 100000m,
            interestRate: .05m,         // 5% annual interest rate
            loanTermMonths: 360,        // 30 years (360 months)
            roundingPrecision: 2,
            paymentRoundingMethod: MidpointRounding.ToPositiveInfinity
        );

        AmortizationSchedule expectedSchedule = AmortizationSchedule.Create(
            paymentSchedule: [],
            paymentAmount: 536.83m,
            finalPaymentAmount: 529.72m,
            totalInterestPaid: 93251.69m,
            totalPrincipalPaid: 100000.00m
        );

        // Act
        AmortizationSchedule amortizationSchedule = new();
        AmortizationScheduleItem amortizationScheduleItem = new();
        AmortizationScheduleItemCalculator amortizationScheduleItemCalculator = new(amortizationScheduleItem);
        AmortizationPaymentCalculator amortizationPaymentCalculator = new();

        AmortizationScheduleCalculator amortizationScheduleCalculator = new(amortizationSchedule, amortizationScheduleItemCalculator, amortizationPaymentCalculator);
        IAmortizationSchedule result = amortizationScheduleCalculator.GetAmortizationSchedule(loanTerms);

        // Assert
        Assert.Equal(expectedSchedule.PaymentAmount, result.PaymentAmount);
        Assert.Equal(expectedSchedule.FinalPaymentAmount, result.FinalPaymentAmount);
        Assert.Equal(expectedSchedule.TotalInterestPaid, result.TotalInterestPaid);
        Assert.Equal(expectedSchedule.TotalPrincipalPaid, result.TotalPrincipalPaid);
        Assert.Equal(360, result.PaymentSchedule.Count());
    }
}
