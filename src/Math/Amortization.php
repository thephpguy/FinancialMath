<?php
namespace FinancialMath\Math;

/**
 * Provides all the logic needed to run accurate amortization calculations
 *
 * Class Amortization
 * @package FinancialMath\Math
 */
abstract class Amortization extends MathBase
{

    private $principal;
    private $annualRate;
    private $months;

    private $roundToTheBanksFavor;


    /**
     * @return float
     * @throws \Exception
     */
    protected function amortizedPayment()
    {
        if(!$this->verifyRequiredData())
        {
            throw new \Exception('Required data is not set.');
        }
        
        try {
            $monthlyRate = $this->getMonthlyRate();
        } catch (\Exception $exception)
        {
            return $exception->getMessage();
        }

        $r = 1+$monthlyRate;
        $d = pow($r, $this->months);
        $g = ($monthlyRate*$d) / ($d - 1);
        return $g * $this->principal;
    }

    /**
     * @return bool
     */
    final public function verifyRequiredData()
    {
        if(isset($this->months) && isset($this->principal) && isset($this->annualRate))
        {
            return true;
        }
        return false;
    }


    /**
     *
     *
     * @return array|string
     * @throws \Exception
     */
    protected function amortizationTable()
    {
        if(!$this->verifyRequiredData())
        {
            throw new \Exception('Required data is not set.');
        }

        try {
            $monthlyRate = $this->getMonthlyRate();
        } catch (\Exception $exception)
        {
            return $exception->getMessage();
        }

        $balance = $this->principal;

        if($this->roundToTheBanksFavor)
        {
            $amortizedPaymentAmount = $this->roundUp($this->amortizedPayment(), 2);
        }else{
            $amortizedPaymentAmount = round($this->amortizedPayment(), 2);
        }

        $amortizationTable = array();
        $interestPaid = 0;
        $paymentNumber = 0;
        $adjustment = 0;
        while($balance > 0)
        {
            $paymentNumber++;
            $interest = round($monthlyRate*$balance, 2);
            $principlePaidThisMonth = $amortizedPaymentAmount-$interest;

            // Last payment will be adjusted up or down by the remaining balance.
            // This happens because of rounding up or down to the nearest cent.
            if($paymentNumber == $this->getMonths())
            {
                $adjustment = round($balance - $principlePaidThisMonth, 2); //If you wonder why this is rounded then see the float warning here: https://www.php.net/manual/en/language.types.float.php
                $principlePaidThisMonth = $balance; // === $principlePaidThisMonth == $principlePaidThisMonth + $adjustment; // 13+(-1), or 13 + 1
            }

            $amortizationTable[] = array(
                'paymentNumber' => $paymentNumber,
                'principal' => $principlePaidThisMonth,
                'interest' => $interest
            );

            $interestPaid += $interest;
            $balance = round($balance - $principlePaidThisMonth, 2);
        }

        $amortizedData = array(
            'amortizationTable'     => $amortizationTable,
            'amortizedPayment'      => $amortizedPaymentAmount,
            'totalPaymentAmount'    => $amortizedPaymentAmount * $this->months + $adjustment,
            'totalInterestAmount'   => $interestPaid,
            'lastMonthAdjustment'   => $adjustment,
        );

        return $amortizedData;
    }


    /**
     * @param $principal
     * @param $rate
     * @param $months
     * @throws \Exception
     */
    final public function setLoanTerms($principal, $rate, $months)
    {
        try {
            $this->setPrincipal($principal);
        }catch (\Exception $exception)
        {
            throw $exception;
        }

        try {
            $this->setAnnualRate($rate);
        }catch (\Exception $exception)
        {
            throw $exception;
        }

        try{
            $this->setMonths($months);
        }catch (\Exception $exception)
        {
            throw $exception;
        }
    }


    /**
     * @return \Exception|float|int
     * @throws \Exception
     */
    public function getMonthlyRate()
    {
        if(isset($this->annualRate) && $this->annualRate > 0 && $this->annualRate < 1)
        {
            return $this->annualRate/12;
        }

        throw new \Exception('Rate is not set.');
    }


    /**
     * @return mixed
     */
    public function getPrincipal()
    {
        return $this->principal;
    }


    /**
     * @param $principal
     * @return bool
     * @throws \Exception
     */
    public function setPrincipal($principal)
    {
        if($principal > 0)
        {
            $this->principal = $principal;
            return true;
        }

        throw new \Exception('Principal must be > 0');
    }


    /**
     * @return mixed
     */
    public function getAnnualRate()
    {
        return $this->annualRate;
    }


    /**
     * @param $rate
     * @return bool
     * @throws \Exception
     */
    public function setAnnualRate($rate)
    {
        if($rate > 0 && $rate < 1) {
            $this->annualRate = $rate;
            return true;
        }
        throw new \Exception('Rate must be > 0 and < 1.');
    }


    /**
     * @return mixed
     */
    public function getMonths()
    {
        return $this->months;
    }


    /**
     * @param $months
     * @return bool
     * @throws \Exception
     */
    public function setMonths($months)
    {
        if($months > 0)
        {
            $this->months = $months;
            return true;
        }
        throw new \Exception('Months must be > 0');
    }

    /**
     * @return bool
     */
    public function getRoundToTheBanksFavor()
    {
        return $this->roundToTheBanksFavor;
    }

    /**
     * @param bool $roundToTheBanksFavor
     */
    public function setRoundToTheBanksFavor($roundToTheBanksFavor)
    {
        if($roundToTheBanksFavor == true){
            $this->roundToTheBanksFavor = true;
        }else{
            $this->roundToTheBanksFavor = false;
        }
    }

}