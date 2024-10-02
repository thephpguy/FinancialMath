namespace FinancialMath.Interfaces;

public interface IAmortizationScheduleItem
{
    int PaymentNumber { get; }
    decimal Interest { get; }
    decimal Principal { get; }
    decimal Balance { get; }

    IAmortizationScheduleItem CreateAmortizationScheduleItem(
        int paymentNumber,
        decimal interest,
        decimal principal,
        decimal balance
    );
}
