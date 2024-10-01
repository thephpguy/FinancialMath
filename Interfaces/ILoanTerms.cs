namespace FinancialMath.Amortization.Interfaces;

public interface ILoanTerms
{
    decimal LoanAmount { get; init; }
    decimal InterestRate { get; }
    int LoanTermMonths { get; }
    MidpointRounding PaymentRoundingMethod { get; }
    MidpointRounding AmortizationRoundingMethod { get; }
    int RoundingPrecision { get; }
    decimal MonthlyInterestRate { get; }
}
