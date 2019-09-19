<?php
namespace FinancialMath;
use FinancialMath\Math\Amortization;

class AmortizationCalculator extends Amortization
{
    function __construct() {}

    /**
     * @return bool|float
     * @throws \Exception
     */
    public function simpleAmortizedPayment()
    {
        return round($this->amortizedPayment(), 2);
    }

    /**
     * @return array|bool|string
     * @throws \Exception
     */
    public function getTable()
    {
        return $this->amortizationTable();
    }
}