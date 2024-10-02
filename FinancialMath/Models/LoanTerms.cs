namespace FinancialMath.Amortization.Models;

using FinancialMath.Interfaces;

/// <summary>
/// Represents the terms of a loan, including principal, interest rate, term, and rounding options.
/// </summary>
public sealed record LoanTerms : ILoanTerms
{
    /// <summary>
    /// Gets the loan principal.
    /// </summary>
    public decimal LoanAmount { get; init; }

    /// <summary>
    /// Gets the annual interest rate (in percentage). For example, 5.0 for 5%.
    /// </summary>
    public decimal InterestRate { get; init; }

    /// <summary>
    /// Gets the number of months in the loan term.
    /// </summary>
    public int LoanTermMonths { get; init; }

    /// <summary>
    /// Gets the rounding method for calculating loan payment.
    /// </summary>
    public MidpointRounding PaymentRoundingMethod { get; init; } = MidpointRounding.ToPositiveInfinity;

    /// <summary>
    /// Gets the rounding method for calculating amortization schedule.
    /// </summary>
    public MidpointRounding AmortizationRoundingMethod { get; init; } = MidpointRounding.AwayFromZero;

    /// <summary>
    /// Gets the number of significant digits to round to.
    /// Default is 2.
    /// </summary>
    public int RoundingPrecision { get; init; } = 2;

    /// <summary>
    /// Gets the monthly interest rate based on the annual interest rate.
    /// </summary>
    public decimal MonthlyInterestRate => InterestRate / 12 / 100;

    /// <summary>
    /// Creates a new instance of the <see cref="LoanTerms"/> class.
    /// </summary>
    /// <param name="loanAmount">The loan principal amount.</param>
    /// <param name="interestRate">The annual interest rate (in percentage).</param>
    /// <param name="loanTermMonths">The number of months in the loan term.</param>
    /// <param name="roundingMethod">The rounding method for calculations. Default MidpointRounding.AwayFromZero</param>
    /// <param name="roundingPrecision">The number of significant digits to round to. Default 2.</param>
    /// <returns>A new instance of the <see cref="LoanTerms"/> class.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="principal"/> is less than or equal to zero.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="interestRate"/> is zero.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="term"/> is less than or equal to zero.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="roundingPrecision"/> is less than zero or greater than 28.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="interestRate"/> is greater than 100.</exception>
    public static LoanTerms Create(
        decimal loanAmount,
        decimal interestRate,
        int loanTermMonths,
        MidpointRounding paymentRoundingMethod = MidpointRounding.ToPositiveInfinity,
        MidpointRounding amortizationRoundingMethod = MidpointRounding.AwayFromZero,
        int roundingPrecision = 2
    ) => new(loanAmount, interestRate, loanTermMonths, paymentRoundingMethod, amortizationRoundingMethod, roundingPrecision);

    private LoanTerms(
        decimal loanAmount,
        decimal interestRate,
        int loanTermMonths,
        MidpointRounding paymentRoundingMethod = MidpointRounding.ToPositiveInfinity,
        MidpointRounding amortizationRoundingMethod = MidpointRounding.AwayFromZero,
        int roundingPrecision = 2
    )
    {
        if (loanAmount <= 0)
        {
            throw new ArgumentException("Loan Amount must be greater than zero.", nameof(loanAmount));
        }

        if (interestRate == 0)
        {
            throw new ArgumentException("Interest rate cannot be zero.", nameof(interestRate));
        }

        if (loanTermMonths <= 0)
        {
            throw new ArgumentException("Loan term must be greater than zero.", nameof(loanTermMonths));
        }

        if (roundingPrecision is < 0 or > 28)
        {
            throw new ArgumentException("Significant digits must be between 0 and 28.", nameof(roundingPrecision));
        }

        if (interestRate > 100)
        {
            throw new ArgumentException("Interest rate cannot be greater than 100%.", nameof(interestRate));
        }

        LoanAmount = loanAmount;
        InterestRate = interestRate;
        LoanTermMonths = loanTermMonths;
        PaymentRoundingMethod = paymentRoundingMethod;
        AmortizationRoundingMethod = amortizationRoundingMethod;
        RoundingPrecision = roundingPrecision;
    }
}
