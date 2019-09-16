<?php

use PHPUnit\Framework\TestCase;
use AmortizationCalculator\AmortizationCalculator;

final class AmortizationCalculatorTest extends TestCase {

    public function testSimpleAmortization()
    {
        $amortizationCalculator = new AmortizationCalculator();

        //3326.512475895912 rounds down.
        $amortizationCalculator->setLoanTerms(500000, .07, 360);
        $monthlyPayment = $amortizationCalculator->simpleAmortizedPayment();
        self::assertEquals(3326.51, $monthlyPayment);

        $amortizationCalculator->setLoanTerms(100000, .05, 360);
        $monthlyPayment = $amortizationCalculator->simpleAmortizedPayment();
        self::assertEquals(536.82, $monthlyPayment);

        //Rounds up. 439.60907717398777
        $amortizationCalculator->setLoanTerms(100000, .0333, 360);
        $monthlyPayment = $amortizationCalculator->simpleAmortizedPayment();
        self::assertEquals(439.61, $monthlyPayment);
    }


    public function testGetTableBasicWithMortgage1()
    {
        $amortizationCalculator = new AmortizationCalculator();
        $months = 180;
        try
        {
            $amortizationCalculator->setLoanTerms(113200, .035, $months);
        }catch (\Exception $exception)
        {
            self::assertTrue(false);
        }

        $table = $amortizationCalculator->getTable();
        unset($amortizationCalculator);

        self::assertEquals($months, count($table['amortizationTable']));
        self::assertEquals(809.25, $table['amortizedPayment']);
        self::assertEquals(145664.28, $table['totalPaymentAmount']);
        self::assertEquals(32464.28, $table['totalInterestAmount']);
        self::assertEquals(-0.72, $table['lastMonthAdjustment']);
    }


    public function testGetTableBasicWithMortgage2()
    {
        $amortizationCalculator = new AmortizationCalculator();
        $months = 180;
        try
        {
            $amortizationCalculator->setLoanTerms(152000, .03375, $months);
        }catch (\Exception $exception)
        {
            self::assertTrue(false);
        }

        $table = $amortizationCalculator->getTable();
        unset($amortizationCalculator);

        self::assertEquals($months, count($table['amortizationTable']));
        self::assertEquals(1077.31, $table['amortizedPayment']);
        self::assertEquals(193916.88, $table['totalPaymentAmount']);
        self::assertEquals(41916.88, $table['totalInterestAmount']);
        self::assertEquals(1.08, $table['lastMonthAdjustment']);
    }


    public function testGetTableBasicWithMortgage3()
    {
        $amortizationCalculator = new AmortizationCalculator();
        $amortizationCalculator->setRoundToTheBanksFavor(true);
        $months = 180;
        try
        {
            $amortizationCalculator->setLoanTerms(152000, .03375, $months);
        }catch (\Exception $exception)
        {
            self::assertTrue(false);
        }

        $table = $amortizationCalculator->getTable();
        unset($amortizationCalculator);

        self::assertEquals($months, count($table['amortizationTable']));
        self::assertEquals(1077.32, $table['amortizedPayment']);
        self::assertEquals(193916.49, $table['totalPaymentAmount']);
        self::assertEquals(41916.49, $table['totalInterestAmount']);
        self::assertEquals(-1.11, $table['lastMonthAdjustment']);
    }
}