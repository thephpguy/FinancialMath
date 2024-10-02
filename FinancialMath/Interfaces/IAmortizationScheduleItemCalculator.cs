namespace FinancialMath.Interfaces;

public interface IAmortizationScheduleItemCalculator
{
    IAmortizationScheduleItem CalculateAmortizationScheduleItem(
        ILoanTerms loanTerms,
        decimal remainingBalance,
        decimal monthlyPayment,
        decimal monthlyInterestRate,
        int paymentNumber
    );
}
