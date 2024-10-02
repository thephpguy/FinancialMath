namespace FinancialMath.Amortization.Tests;
using FinancialMath.Amortization.Models;
using FinancialMath.Core.Amortization;
using Xunit;

public class GetAmortizedPaymentTests
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

        // Act
        AmortizationPaymentCalculator paymentCalculator = new();
        decimal result = paymentCalculator.GetAmortizedPayment(loanTerms);

        // Assert
        Assert.Equal(536.83m, result);  // Expected monthly payment
    }

    [Fact]
    public void CalculateAmortizedPayment_ValidTerms_ReturnsCorrectAmount2()
    {
        // Arrange
        LoanTerms loanTerms = LoanTerms.Create(
            loanAmount: 152000m,
            interestRate: .03375m,           // 3.375% annual interest rate
            loanTermMonths: 180,            // 15 years (180 months)
            roundingPrecision: 2,
            paymentRoundingMethod: MidpointRounding.ToPositiveInfinity
        );

        // Act
        AmortizationPaymentCalculator paymentCalculator = new();
        decimal result = paymentCalculator.GetAmortizedPayment(loanTerms);

        // Assert
        Assert.Equal(1077.32m, result);  // Expected monthly payment
    }


    [Fact]
    public void CalculateAmortizedPayment_ValidTerms_ReturnsCorrectAmount3()
    {
        // Arrange
        LoanTerms loanTerms = LoanTerms.Create(
            loanAmount: 77777.77m,
            interestRate: .0777m,
            loanTermMonths: 180,
            roundingPrecision: 2
        );

        // Act
        AmortizationPaymentCalculator paymentCalculator = new();
        decimal result = paymentCalculator.GetAmortizedPayment(loanTerms);

        // Assert
        Assert.Equal(733.00m, result);  // Expected monthly payment
    }


    [Fact]
    public void CalculateAmortizedPayment_InvalidInterestRate_ThrowsError()
    {
        try
        {
            // Arrange
            LoanTerms loanTerms = LoanTerms.Create(
                loanAmount: 100000m,
                interestRate: 0m,
                loanTermMonths: 180,
                roundingPrecision: 2
            );
        }
        catch (ArgumentException ex)
        {
            // Assert
            Assert.Equal("Interest rate cannot be zero. (Parameter 'interestRate')", ex.Message);
        }
    }

    [Fact]
    public void CalculateAmortizedPayment_InvalidTerm_ThrowsError()
    {
        // Arrange
        try
        {
            LoanTerms loanTerms = LoanTerms.Create(
                loanAmount: 100000m,
                interestRate: .05m,
                loanTermMonths: 0,
                roundingPrecision: 2
            );
        }
        catch (ArgumentException ex)
        {
            // Assert
            Assert.Equal("Loan term must be greater than zero. (Parameter 'loanTermMonths')", ex.Message);
        }
    }


    [Fact]
    public void CalculateAmortizedPayment_InvalidPrincipal_ThrowsError()
    {
        try
        {
            LoanTerms loanTerms = LoanTerms.Create(
                loanAmount: 0m,
                interestRate: .05m,
                loanTermMonths: 180,
                roundingPrecision: 2
            );
        }
        catch (ArgumentException ex)
        {
            // Assert
            Assert.Equal("Loan Amount must be greater than zero. (Parameter 'loanAmount')", ex.Message);
        }
    }

    [Fact]
    public void CalculateAmortizedPayment_InvalidLoanTerms_ThrowsError()
    {
        // Arrange
        LoanTerms? loanTerms = null;

        decimal result;
        AmortizationPaymentCalculator paymentCalculator = new();

        // Act
        try
        {
#pragma warning disable CS8604 // Possible null reference argument.
            //Intentionally passing null to test the exception
            result = paymentCalculator.GetAmortizedPayment(loanTerms);
#pragma warning restore CS8604 // Possible null reference argument.
        }
        catch (ArgumentException ex)
        {
            // Assert
            Assert.Equal("Loan terms cannot be null. (Parameter 'loanTerms')", ex.Message);
        }
    }

}
