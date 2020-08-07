<?php
namespace FinancialMath\Math;

class Interest extends MathBase
{

    /**
     * Simple interest amount.
     *  A = P (1 + rt)
     * Returns the total amount of principle+interest for the term.
     *
     * @param int $principle
     * @param float $rate
     * @param int $time
     * @param int $roundPrecision [optional]
     * @return float|int
     */
    final public function simpleInterest($principle, $rate, $time, $roundPrecision = 2){

        $principle = $this->sanitizeFloat($principle);
        $rate = $this->sanitizeFloat($rate);
        $time = $this->sanitizeInteger($time);

        $result = $principle * (1 + $rate * $time);

        return round($result, $roundPrecision);
    }

    /**
     * Compound Interest
     * A = P(1 + (r/n))^nt
     *
     * Returns the total amount of principle+interest for the term.
     *
     * @param $principle
     * @param $rate
     * @param $time
     * @param $frequency
     * @param int $roundPrecision
     * @return mixed
     */
    final public function compoundInterest($principle, $rate, $time, $frequency, $roundPrecision = 2){

        $principle = $this->sanitizeFloat($principle);
        $rate = $this->sanitizeFloat($rate);
        $time = $this->sanitizeInteger($time);
        $frequency = $this->sanitizeInteger($frequency);
        $roundPrecision = $this->sanitizeInteger($roundPrecision);

        $a = 1 + $rate / $frequency;
        $b = $frequency*$time;

        $result = $principle * pow($a, $b);
        return round($result, $roundPrecision);
    }


    //TODO: Present Value of an Ordinary Annuity
    //TODO: Future Value of an Ordinary Annuity
    //TODO: Compound Annual Growth Rate
    //TODO: Leverage Ratio


    
}