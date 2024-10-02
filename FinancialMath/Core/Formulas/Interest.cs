namespace FinancialMath.Core.Formulas;

public static class Interest
{
    /// <summary>
    /// Calculate simple interest
    /// </summary>
    /// <param name="principal"></param>
    /// <param name="rate"></param>
    /// <param name="periods"></param>
    /// <returns></returns>
    public static decimal SimpleInterest(decimal principal, decimal rate, int periods)
    {
        return principal * rate * periods;
    }


    /// <summary>
    /// Calculate compound interest using the formula: B(t) = P(1 + r/n)^(nt)
    ///     Where:
    ///     B(t) = the future value of the investment/loan, including interest.
    ///     P = the principal investment amount (the initial deposit or loan amount).
    ///     r = the annual interest rate(decimal).
    ///     n = the number of times that interest is compounded per year.
    ///     t = the time the money is invested/borrowed for, in years.
    /// </summary>
    /// <param name="principal"></param>
    /// <param name="annualInterestRate"></param>
    /// <param name="timesCompoundedPerYear"></param>
    /// <param name="years"></param>
    /// <returns></returns>
    public static decimal CompoundInterest(decimal principal, decimal annualInterestRate, int timesCompoundedPerYear, int years)
    {
        decimal ratePerPeriod = annualInterestRate / timesCompoundedPerYear;
        decimal baseValue = 1 + ratePerPeriod;
        decimal exponent = timesCompoundedPerYear * years;
        double baseValueDouble = (double)baseValue;
        double exponentDouble = (double)exponent;

        return principal * (decimal)Math.Pow(baseValueDouble, exponentDouble);
    }


    /// <summary>
    /// Calculate continuous compound interest using the formula: FV = PV * [1 + (r/n)](rt)
    ///     Where:
    ///     FV = the future value of the investment/loan, including interest.
    ///     PV = the principal investment amount (the initial deposit or loan amount).
    ///     r = the annual interest rate(decimal).
    ///     t = the time the money is invested/borrowed for.
    /// </summary>
    /// <param name="principal"></param>
    /// <param name="rate"></param>
    /// <param name="periods"></param>
    public static decimal ContinuousCompoundInterest(decimal principal, decimal rate, int periods)
    {
        return principal * (decimal)Math.Exp((double)(rate * periods));
    }


    /// <summary>
    /// Calculate the monthly interest rate
    /// </summary>
    /// <param name="annualInterestRate">Annual interest rate expressed as a decimal. IE .05 for a 5% rate.</param>
    /// <returns>Monthly interest rate.</returns>
    public static decimal MonthlyInterestRate(decimal annualInterestRate)
    {
        return annualInterestRate / 12;
    }


    public static decimal MonthlyPayment(decimal loanAmount, decimal annualInterestRate, int numberOfPayments)
    {
        decimal monthlyInterestRate = MonthlyInterestRate(annualInterestRate);
        return loanAmount * monthlyInterestRate / (1 - (decimal)Math.Pow(1 + (double)monthlyInterestRate, -numberOfPayments));
    }

}
