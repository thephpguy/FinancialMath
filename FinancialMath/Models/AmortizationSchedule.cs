namespace FinancialMath.Amortization.Models;

using System.Collections.Generic;
using FinancialMath.Interfaces;

public sealed record AmortizationSchedule : IAmortizationSchedule
{

    public AmortizationSchedule()
    {
    }

    public IEnumerable<IAmortizationScheduleItem> PaymentSchedule { get; init; } = default!;
    public decimal PaymentAmount { get; init; }
    public decimal FinalPaymentAmount { get; init; }
    public decimal TotalInterestPaid { get; init; }
    public decimal TotalPrincipalPaid { get; init; }

    private AmortizationSchedule(
        IEnumerable<IAmortizationScheduleItem> paymentSchedule,
        decimal paymentAmount,
        decimal finalPaymentAmount,
        decimal totalInterestPaid,
        decimal totalPrincipalPaid
    )
    {
        PaymentSchedule = paymentSchedule;
        PaymentAmount = paymentAmount;
        FinalPaymentAmount = finalPaymentAmount;
        TotalInterestPaid = totalInterestPaid;
        TotalPrincipalPaid = totalPrincipalPaid;
    }


    public static AmortizationSchedule Create(
        IEnumerable<IAmortizationScheduleItem> paymentSchedule,
        decimal paymentAmount,
        decimal finalPaymentAmount,
        decimal totalInterestPaid,
        decimal totalPrincipalPaid
    )
    => new(paymentSchedule, paymentAmount, finalPaymentAmount, totalInterestPaid, totalPrincipalPaid);

    public IAmortizationSchedule CreateAmortizationSchedule(
        IEnumerable<IAmortizationScheduleItem> paymentSchedule,
        decimal paymentAmount,
        decimal finalPaymentAmount,
        decimal totalInterestPaid,
        decimal totalPrincipalPaid) => Create(paymentSchedule, paymentAmount, finalPaymentAmount, totalInterestPaid, totalPrincipalPaid);
}
