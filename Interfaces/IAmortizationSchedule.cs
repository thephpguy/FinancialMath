namespace FinancialMath.Interfaces;

public interface IAmortizationSchedule
{
    IEnumerable<IAmortizationScheduleItem> PaymentSchedule { get; }
    decimal PaymentAmount { get; }
    decimal FinalPaymentAmount { get; }
    decimal TotalInterestPaid { get; }
    decimal TotalPrincipalPaid { get; }

    IAmortizationSchedule CreateAmortizationSchedule(
        IEnumerable<IAmortizationScheduleItem> paymentSchedule,
        decimal paymentAmount,
        decimal finalPaymentAmount,
        decimal totalInterestPaid,
        decimal totalPrincipalPaid
    );
}
