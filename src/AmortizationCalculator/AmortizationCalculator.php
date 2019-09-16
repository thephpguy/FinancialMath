<?php

namespace AmortizationCalculator;

use AmortizationCalculator\FinancialMath\Amortization;

class AmortizationCalculator extends Amortization
{
    function __construct() {}


    public function simpleAmortizedPayment()
    {
        return round($this->amortizedPayment(), 2);
    }


    public function amortizedPaymentAmount()
    {
        return $this->amortizedPayment();
    }


    public function getTable(){
        return $this->amortizationTable();
    }

}