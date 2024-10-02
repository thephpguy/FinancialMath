namespace FinancialMath.Core.Amortization;

using FinancialMath.Interfaces;

public class AmortizationScheduleCalculator(
    IAmortizationSchedule amortizationSchedule,
    IAmortizationScheduleItemCalculator amortizationScheduleItemCalculator,
    IAmortizationPaymentCalculator amortizationPaymentCalculator
)
{
    private readonly IAmortizationSchedule _amortizationSchedule = amortizationSchedule;
    private readonly IAmortizationScheduleItemCalculator _amortizationScheduleItemCalculator = amortizationScheduleItemCalculator;
    private readonly IAmortizationPaymentCalculator _amortizationPaymentCalculator = amortizationPaymentCalculator;

    private const decimal ZeroBalance = 0;

    public IAmortizationSchedule GetAmortizationSchedule(ILoanTerms loanTerms)
    {

        decimal monthlyPayment = _amortizationPaymentCalculator.GetAmortizedPayment(loanTerms);
        int paymentNumber = 1;
        decimal interestPaid = 0;
        decimal principalPaid = 0;
        decimal remainingBalance = loanTerms.LoanAmount;
        decimal monthlyInterestRate = loanTerms.MonthlyInterestRate;
        decimal finalPaymentAmount = 0;

        List<IAmortizationScheduleItem> paymentSchedule = [];

        while (remainingBalance > 0)
        {
            IAmortizationScheduleItem amortizationScheduleItem = _amortizationScheduleItemCalculator.CalculateAmortizationScheduleItem(
                loanTerms,
                remainingBalance,
                monthlyPayment,
                monthlyInterestRate,
                paymentNumber
            );

            if (amortizationScheduleItem.Balance == ZeroBalance)
            {
                finalPaymentAmount = decimal.Round(remainingBalance + amortizationScheduleItem.Interest, loanTerms.RoundingPrecision, loanTerms.AmortizationRoundingMethod);
            }

            interestPaid += amortizationScheduleItem.Interest;
            principalPaid += amortizationScheduleItem.Principal;
            remainingBalance = amortizationScheduleItem.Balance;

            paymentSchedule.Add(amortizationScheduleItem);

            paymentNumber++;
        }

        IAmortizationSchedule amortizationSchedule = _amortizationSchedule.CreateAmortizationSchedule(
            paymentSchedule: paymentSchedule,
            paymentAmount: monthlyPayment,
            finalPaymentAmount: finalPaymentAmount,
            totalInterestPaid: decimal.Round(interestPaid, loanTerms.RoundingPrecision, loanTerms.AmortizationRoundingMethod),
            totalPrincipalPaid: decimal.Round(principalPaid, loanTerms.RoundingPrecision, loanTerms.AmortizationRoundingMethod)
        );

        return amortizationSchedule;
    }
}
