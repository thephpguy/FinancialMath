namespace FinancialMath.Core.Amortization.Provider;

using FinancialMath.Interfaces;

/// <summary>
/// Provides a simple way to create an amortization schedule. No need to inject dependencies.
/// </summary>
public static class AmortizationScheduleProvider
{
    public static IAmortizationSchedule GetAmortizationSchedule(ILoanTerms loanTerms)
    {
        // Use the factory to create the default calculator
        AmortizationScheduleCalculator amortizationScheduleCalculator = AmortizationScheduleProviderFactory.CreateDefaultCalculator();
        return amortizationScheduleCalculator.GetAmortizationSchedule(loanTerms);
    }
}
