namespace FinancialMath.Core.Amortization;

using FinancialMath.Amortization.Models;

/// <summary>
/// Provides a simple way to create an amortization schedule with default settings.
/// </summary>
public static class AmortizationScheduleProviderFactory
{
    public static AmortizationScheduleCalculator CreateDefaultCalculator()
    {
        AmortizationSchedule amortizationSchedule = new();
        AmortizationScheduleItem amortizationScheduleItem = new();
        AmortizationScheduleItemCalculator amortizationScheduleItemCalculator = new(amortizationScheduleItem);
        AmortizationPaymentCalculator amortizationPaymentCalculator = new();

        return new AmortizationScheduleCalculator(
            amortizationSchedule,
            amortizationScheduleItemCalculator,
            amortizationPaymentCalculator
        );
    }
}
