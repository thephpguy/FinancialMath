namespace FinancialMath.Amortization.Tests;

using FinancialMath.Core.Formulas;
using Xunit;

public class InterestTests
{
    [Fact]
    public void SimpleInterest_ReturnsCorrectValue()
    {
        // Arrange
        decimal principal = 1000;
        decimal rate = 0.05m;
        int periods = 12;

        // Act
        decimal result = Interest.SimpleInterest(principal, rate, periods);

        // Assert
        Assert.Equal(600, result);
    }

    [Fact]
    public void CompoundInterest_OneYearCompoundedMonthly_ReturnsCorrectValue()
    {
        // Arrange
        decimal principal = 1000;
        decimal annualInterestRate = 0.05m;
        int timesCompoundedPerYear = 12;
        int years = 1;

        // Act
        decimal result = Interest.CompoundInterest(principal, annualInterestRate, timesCompoundedPerYear, years);

        // Assert
        Assert.Equal(1051.16189788173000m, result);
    }


    [Fact]
    public void CompoundInterest_OneYearCompoundedAnnually_ReturnsCorrectValue()
    {
        // Arrange
        decimal principal = 1000;
        decimal annualInterestRate = 0.05m;
        int timesCompoundedPerYear = 1;
        int years = 1;

        // Act
        decimal result = Interest.CompoundInterest(principal, annualInterestRate, timesCompoundedPerYear, years);

        // Assert
        Assert.Equal(1050m, result);
    }

    [Fact]
    public void CompoundInterest_TenYearsCompoundedMonthly_ReturnsCorrectValue()
    {
        // Arrange
        decimal principal = 1000;
        decimal annualInterestRate = 0.05m;
        int timesCompoundedPerYear = 12;
        int years = 10;

        // Act
        decimal result = Interest.CompoundInterest(principal, annualInterestRate, timesCompoundedPerYear, years);

        // Assert
        Assert.Equal(1647.00949769028000m, result);
    }



    [Fact]
    public void ContinuousCompoundInterest_OneTimeValue_ReturnsCorrectValue()
    {
        // Arrange
        decimal principal = 1000;
        decimal rate = 0.05m;
        int time = 1;

        // Act
        decimal result = Interest.ContinuousCompoundInterest(principal, rate, time);

        // Assert
        Assert.Equal(1051.27109637602000m, result);
    }


    [Fact]
    public void ContinuousCompoundInterest_TwentyPeriods_ReturnsCorrectValue()
    {
        // Arrange
        decimal principal = 1000;
        decimal rate = 0.05m;
        int time = 20;

        // Act
        decimal result = Interest.ContinuousCompoundInterest(principal, rate, time);

        // Assert
        Assert.Equal(2718.28182845904000m, result);
    }

    [Fact]
    public void ContinuousCompoundInterest_TwentyFourPeriods_ReturnsCorrectValue()
    {
        // Arrange
        decimal principal = 1000;
        decimal rate = 0.05m;
        int time = 24;

        // Act
        decimal result = Interest.ContinuousCompoundInterest(principal, rate, time);

        // Assert
        Assert.Equal(3320.11692273655000m, result);
    }


    [Fact]
    public void MonthlyInterestRate_Test1_ReturnsCorrectValue()
    {
        // Arrange
        decimal rate = 0.05m;

        // Act
        decimal result = Interest.MonthlyInterestRate(rate);

        // Assert
        Assert.Equal(.0041666666666666666666666667m, result);
    }


    [Fact]
    public void MonthlyInterestRate_Test2_ReturnsCorrectValue()
    {
        // Arrange
        decimal rate = 0.13m;

        // Act
        decimal result = Interest.MonthlyInterestRate(rate);

        // Assert
        Assert.Equal(.0108333333333333333333333333m, result);
    }

    [Fact]
    public void MonthlyPayment_Test_ReturnsCorrectValue()
    {
        // Arrange
        decimal loanAmount = 1000;
        decimal annualInterestRate = 0.05m;
        int numberOfPayments = 12;

        // Act
        decimal monthlyPayment = Interest.MonthlyPayment(loanAmount, annualInterestRate, numberOfPayments);

        // Assert
        Assert.Equal(85.60748178846803824759270068m, monthlyPayment);
    }
}