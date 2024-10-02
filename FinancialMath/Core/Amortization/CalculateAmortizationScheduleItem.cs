namespace FinancialMath.Core.Amortization;


using FinancialMath.Interfaces;

public class AmortizationScheduleItemCalculator(IAmortizationScheduleItem amortizationScheduleItem) : IAmortizationScheduleItemCalculator
{
    private readonly IAmortizationScheduleItem _amortizationScheduleItem = amortizationScheduleItem;

    public IAmortizationScheduleItem CalculateAmortizationScheduleItem(
        ILoanTerms loanTerms,
        decimal remainingBalance,
        decimal monthlyPayment,
        decimal monthlyInterestRate,
        int paymentNumber
    )
    {
        decimal interestPayment = decimal.Round(remainingBalance * monthlyInterestRate, loanTerms.RoundingPrecision, loanTerms.AmortizationRoundingMethod);
        decimal principalPayment;

        if (loanTerms.LoanTermMonths == paymentNumber)
        {
            principalPayment = decimal.Round(remainingBalance, loanTerms.RoundingPrecision, loanTerms.AmortizationRoundingMethod);
            remainingBalance = 0;
        }
        else
        {
            principalPayment = monthlyPayment - interestPayment;
            remainingBalance -= principalPayment;
        }

        return _amortizationScheduleItem.CreateAmortizationScheduleItem(paymentNumber, interestPayment, principalPayment, remainingBalance);
    }
}
