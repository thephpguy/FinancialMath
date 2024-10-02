namespace FinancialMath.Interfaces;

public interface IAmortizationPaymentCalculator
{
    /// <summary>
    /// Calculates the monthly amortized payment based on the provided loan terms.
    /// </summary>
    /// <param name="loanTerms">The terms of the loan, including principal, interest rate, and term.</param>
    /// <returns>The calculated monthly payment.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="loanTerms"/> is null.</exception>
    decimal GetAmortizedPayment(ILoanTerms loanTerms);
}

