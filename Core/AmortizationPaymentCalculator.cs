namespace FinancialMath.Amortization;

using FinancialMath.Amortization.Interfaces;


/// <summary>
/// Provides methods to calculate amortized payments for loans.
/// </summary>
public class AmortizationPaymentCalculator
{
    /// <summary>
    /// Calculates the monthly amortized payment based on the provided loan terms.
    /// </summary>
    /// <param name="loanTerms">The terms of the loan, including principal, interest rate, and term.</param>
    /// <returns>The calculated monthly payment.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="loanTerms"/> is null.</exception>
    public static decimal GetAmortizedPayment(ILoanTerms loanTerms)
    {
        if (loanTerms == null)
        {
            throw new ArgumentNullException(nameof(loanTerms), "Loan terms cannot be null.");
        }

        decimal monthlyInterestRate = loanTerms.MonthlyInterestRate;

        decimal monthlyPayment = loanTerms.LoanAmount * monthlyInterestRate
            / (1 - (decimal)Math.Pow(1 + (double)monthlyInterestRate, -loanTerms.LoanTermMonths));

        return decimal.Round(monthlyPayment, loanTerms.RoundingPrecision, loanTerms.PaymentRoundingMethod);
    }

}
