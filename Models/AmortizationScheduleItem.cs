namespace FinancialMath.Amortization.Models;

using FinancialMath.Interfaces;

public sealed record AmortizationScheduleItem : IAmortizationScheduleItem
{
    /// <summary>
    /// Gets the payment number.
    /// </summary>
    public int PaymentNumber { get; set; }

    /// <summary>
    /// Gets the interest paid for this period.
    /// </summary>
    public decimal Interest { get; set; }

    /// <summary>
    /// Gets the principal paid for this period.
    /// </summary>
    public decimal Principal { get; set; }

    /// <summary>
    /// Gets the ending balance after payment.
    /// </summary>
    public decimal Balance { get; set; }


    /// <summary>
    /// Creates a new instance of the <see cref="AmortizationScheduleItem"/> class.
    /// </summary>
    /// <param name="paymentNumber"></param>
    /// <param name="interest"></param>
    /// <param name="principal"></param>
    /// <param name="balance"></param>
    private AmortizationScheduleItem(int paymentNumber, decimal interest, decimal principal, decimal balance)
    {
        PaymentNumber = paymentNumber;
        Interest = interest;
        Principal = principal;
        Balance = balance;
    }

    public AmortizationScheduleItem()
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="AmortizationScheduleItem"/> class.
    /// </summary>
    /// <param name="paymentNumber"></param>
    /// <param name="interest"></param>
    /// <param name="principal"></param>
    /// <param name="balance"></param>
    /// <returns></returns>
    public static AmortizationScheduleItem Create(
        int paymentNumber,
        decimal interest,
        decimal principal,
        decimal balance
    ) => new(paymentNumber, interest, principal, balance);

    public IAmortizationScheduleItem CreateAmortizationScheduleItem(
        int paymentNumber,
        decimal interest,
        decimal principal,
        decimal balance
    ) => Create(paymentNumber, interest, principal, balance);
}
