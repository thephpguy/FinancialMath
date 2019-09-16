<?php
use PHPUnit\Framework\TestCase;
use AmortizationCalculator\AmortizationCalculator;


final class FinancialMathAmortizationMathTest extends TestCase
{
    public function testSetRate()
    {
        //Try a whole number.
        $amortizationCalculator = new AmortizationCalculator();
        try{
           $amortizationCalculator->setRate(1);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Rate must be > 0 and < 1.', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getRate());
        unset($amortizationCalculator);


        //Try negative number
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setRate(-1);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Rate must be > 0 and < 1.', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getRate());
        unset($amortizationCalculator);


        // Test rate = 0
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setRate(0);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Rate must be > 0 and < 1.', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getRate());
        unset($amortizationCalculator);


        //Test rate = 0.00
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setRate(0.00);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Rate must be > 0 and < 1.', $exception->getMessage());
        }
        unset($amortizationCalculator);


        //Test rate = 0.00
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setRate('a');
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Rate must be > 0 and < 1.', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getRate());
        unset($amortizationCalculator);


        //Test rate = .01
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setRate(.01);
        }
        catch(\Exception $exception)
        {
            self::assertNull($exception->getMessage()); //Unless we hit an error this code won't actually run.
        }
        self::assertEquals( .01, $amortizationCalculator->getRate());
        unset($amortizationCalculator);


        //Test rate = .01
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setRate(.9999999999999999);
        }
        catch(\Exception $exception)
        {
            self::assertNull($exception->getMessage()); //Unless we hit an error this code won't actually run.
        }
        self::assertEquals(.9999999999999999, $amortizationCalculator->getRate());
    }


    public function testSetMonths()
    {
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setMonths(-1);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Months must be > 0', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getMonths());
        unset($amortizationCalculator);



        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setMonths(0);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Months must be > 0', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getMonths());
        unset($amortizationCalculator);



        //Test invalid letter.
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setMonths('a');
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Months must be > 0', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getMonths());
        unset($amortizationCalculator);




        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setMonths(10);
        }
        catch(\Exception $exception)
        {
            self::assertTrue(false); //setMonths is broken if this test fails.
        }
        self::assertEquals(10, $amortizationCalculator->getMonths());
        unset($amortizationCalculator);

    }


    public function testSetPrincipal()
    {
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setPrincipal(-1);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Principal must be > 0', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getPrincipal());
        unset($amortizationCalculator);




        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setPrincipal(0);
        }
        catch(\Exception $exception)
        {
            self::assertEquals('Principal must be > 0', $exception->getMessage());
        }
        self::assertNull($amortizationCalculator->getPrincipal());
        unset($amortizationCalculator);


        //Test a valid amount
        $amortizationCalculator = new AmortizationCalculator();
        try{
            $amortizationCalculator->setPrincipal(1);
        }
        catch(\Exception $exception)
        {
            self::assertTrue(false); //setPrincipal is broken if this test fails.
        }
        self::assertEquals(1, $amortizationCalculator->getPrincipal());
        unset($amortizationCalculator);
    }


    public function testGetMonthlyRate()
    {
        $amortizationCalculator = new AmortizationCalculator();
        $monthlyRate = null;
        try {
            $monthlyRate = $amortizationCalculator->getMonthlyRate();
        }catch(\Exception $exception)
        {
            self::assertEquals('Rate is not set.', $exception->getMessage());
        }
        self::assertNull($monthlyRate);
        unset($amortizationCalculator);




        $amortizationCalculator = new AmortizationCalculator();
        $monthlyRate = null;
        try{
            $amortizationCalculator->setRate(.05);
        }catch (\Exception $exception)
        {
            self::assertTrue(false);//Assertion won't run. If it does we need to fix something with setRate.
        }

        try {
            $monthlyRate = $amortizationCalculator->getMonthlyRate();
        }catch(\Exception $exception)
        {
            self::assertEquals('Rate is not set.', $exception->getMessage());
        }
        self::assertEquals('0.004166666666666667', $monthlyRate);
        unset($amortizationCalculator);



        $amortizationCalculator = new AmortizationCalculator();
        $monthlyRate = null;
        try{
            $amortizationCalculator->setRate(.12);
        }catch (\Exception $exception)
        {
            self::assertTrue(false); //Assertion won't run. If it does we need to fix something with setRate.
        }

        try {
            $monthlyRate = $amortizationCalculator->getMonthlyRate();
        }catch(\Exception $exception)
        {
            self::assertEquals('Rate is not set.', $exception->getMessage());
        }
        self::assertEquals('0.01', $monthlyRate);
        unset($amortizationCalculator);

    }


    public function testSetLoanTerms()
    {

        $amortizationCalculator = new AmortizationCalculator();

        try
        {
            $amortizationCalculator->setLoanTerms(500001, .004, 180);
        }catch (\Exception $exception)
        {
            self::assertTrue(false);
        }
        self::assertEquals(500001, $amortizationCalculator->getPrincipal());
        self::assertEquals(.004, $amortizationCalculator->getRate());
        self::assertEquals(180, $amortizationCalculator->getMonths());
        unset($amortizationCalculator);



        $amortizationCalculator = new AmortizationCalculator();
        try
        {
            $amortizationCalculator->setLoanTerms(0, .004, 180);
        }catch (\Exception $exception)
        {
            self::assertEquals('Principal must be > 0', $exception->getMessage());
        }
        unset($amortizationCalculator);


        $amortizationCalculator = new AmortizationCalculator();
        try
        {
            $amortizationCalculator->setLoanTerms(100, 0, 180);
        }catch (\Exception $exception)
        {
            self::assertEquals('Rate must be > 0 and < 1.', $exception->getMessage());
        }
        unset($amortizationCalculator);



        $amortizationCalculator = new AmortizationCalculator();
        try
        {
            $amortizationCalculator->setLoanTerms(100, .004, 0);
        }catch (\Exception $exception)
        {
            self::assertEquals('Months must be > 0', $exception->getMessage());
        }
        unset($amortizationCalculator);
    }


    public function testRoundUp()
    {

        $amortizationCalculator = new AmortizationCalculator();

        $test1Result = $amortizationCalculator->roundUp(100.546, 2);
        self::assertEquals(100.55, $test1Result);

        $test2Result = $amortizationCalculator->roundUp(100.544, 2);
        self::assertEquals(100.55, $test2Result);

        $test3Result = $amortizationCalculator->roundUp(0.540000001, 2);
        self::assertEquals(0.54, $test3Result);

        $test4Result = $amortizationCalculator->roundUp(1.55, 2);
        self::assertEquals(1.55, $test4Result);

        $test5Result = $amortizationCalculator->roundUp(0.55, 2);
        self::assertEquals(0.55, $test5Result);

        $test5Result = $amortizationCalculator->roundUp(0.666666666, 6);
        self::assertEquals(0.666667, $test5Result);

        $test5Result = $amortizationCalculator->roundUp(55.666666666, 6);
        self::assertEquals(55.666667, $test5Result);

        $test5Result = $amortizationCalculator->roundUp(10055.666666666, 6);
        self::assertEquals(10055.666667, $test5Result);



        $test1Result = $amortizationCalculator->roundUp(-101.546, 2);
        self::assertEquals(-101.55, $test1Result);

        $test2Result = $amortizationCalculator->roundUp(-100.544, 2);
        self::assertEquals(-100.55, $test2Result);

        $test3Result = $amortizationCalculator->roundUp(-0.540000001, 2);
        self::assertEquals(-0.54, $test3Result);

        $test4Result = $amortizationCalculator->roundUp(-1.55, 2);
        self::assertEquals(-1.55, $test4Result);

        $test5Result = $amortizationCalculator->roundUp(-0.55, 2);
        self::assertEquals(-0.55, $test5Result);

        $test5Result = $amortizationCalculator->roundUp(-0.666666666, 6);
        self::assertEquals(-0.666667, $test5Result);

        $test5Result = $amortizationCalculator->roundUp(-55.666666666, 6);
        self::assertEquals(-55.666667, $test5Result);

        $test5Result = $amortizationCalculator->roundUp(-10055.666666666, 6);
        self::assertEquals(-10055.666667, $test5Result);



        unset($amortizationCalculator);

    }


    public function testRoundDown()
    {
        $amortizationCalculator = new AmortizationCalculator();

        $test1Result = $amortizationCalculator->roundDown(100.546, 2);
        self::assertEquals(100.54, $test1Result);

        $test2Result = $amortizationCalculator->roundDown(100.544, 2);
        self::assertEquals(100.54, $test2Result);

        $test3Result = $amortizationCalculator->roundDown(0.540000001, 2);
        self::assertEquals(0.54, $test3Result);

        $test4Result = $amortizationCalculator->roundDown(1.55, 2);
        self::assertEquals(1.55, $test4Result);

        $test5Result = $amortizationCalculator->roundDown(0.55, 2);
        self::assertEquals(0.55, $test5Result);

        $test5Result = $amortizationCalculator->roundDown(0.666666666, 6);
        self::assertEquals(0.666666, $test5Result);

        $test5Result = $amortizationCalculator->roundDown(55.666666666, 6);
        self::assertEquals(55.666666, $test5Result);

        $test5Result = $amortizationCalculator->roundDown(10055.666666666, 6);
        self::assertEquals(10055.666666, $test5Result);



        $test1Result = $amortizationCalculator->roundDown(-101.546, 2);
        self::assertEquals(-101.54, $test1Result);

        $test2Result = $amortizationCalculator->roundDown(-100.544, 2);
        self::assertEquals(-100.54, $test2Result);

        $test3Result = $amortizationCalculator->roundDown(-0.540000001, 2);
        self::assertEquals(-0.54, $test3Result);

        $test4Result = $amortizationCalculator->roundDown(-1.55, 2);
        self::assertEquals(-1.55, $test4Result);

        $test5Result = $amortizationCalculator->roundDown(-0.55, 2);
        self::assertEquals(-0.55, $test5Result);

        $test5Result = $amortizationCalculator->roundDown(-0.666666666, 6);
        self::assertEquals(-0.666666, $test5Result);

        $test5Result = $amortizationCalculator->roundDown(-55.666666666, 6);
        self::assertEquals(-55.666666, $test5Result);

        $test5Result = $amortizationCalculator->roundDown(-10055.666666666, 6);
        self::assertEquals(-10055.666666, $test5Result);

        unset($amortizationCalculator);
    }

    /*
     * TODO: Consider modifying the entire system to NOT use floating point numbers.
     * Useless test. I put this here for demonstration purposes only.
     *
     */
    public function testRoundingError()
    {
        //clearly 2.1500000000001 != 2.15
        $x = 806.7;     //There are floating issues because there is no way to represent .7 in base 2.
        $y = 804.55;
        $z = $x-$y;

        self::assertEquals(2.1500000000001, $z);
        self::assertEquals(2.15, $z);
    }
}