<?php
use PHPUnit\Framework\TestCase;
use FinancialMath\Math\Interest;


final class InterestTest extends TestCase
{

    public function testSimpleInterest()
    {

        $interestClass = new Interest();

        //Simple test.
        $answer = $interestClass->simpleInterest(100000, .05, 5);
        self::assertEquals(125000, $answer);

        //Simple test with a decimal in the principle
        $answer = $interestClass->simpleInterest(100000.20, .05, 5);
        self::assertEquals(125000.25, $answer);


        //Strings will work.
        $answer = $interestClass->simpleInterest('100000', '.05', '5');
        self::assertEquals(125000, $answer);

        // Sanitize
        $answer = $interestClass->simpleInterest('100,000', "rate0.05", "time5");
        self::assertEquals(125000, $answer);


        //Test some zeros.
        $answer = $interestClass->simpleInterest(0, .00, 0);
        self::assertEquals(0, $answer);

        //Test with a interest rate that can't be represented in binary.
        $answer = $interestClass->simpleInterest(55555, .07, 5);
        self::assertEquals(74999.25, $answer);

        // Large Numbers
        $answer = $interestClass->simpleInterest(9999999999, .0555, 30, 3);
        self::assertEquals(26649999997.335, $answer);

        //Simple test.
        $answer = $interestClass->simpleInterest(100000, .05, 5);
        self::assertEquals(125000, $answer);


        //Test 3 decimals.
        $answer = $interestClass->simpleInterest(100001, .053, 5, 3);
        self::assertEquals(126501.265, $answer);

        //Test rounding up
        $answer = $interestClass->simpleInterest(100001, .053, 5, 2);
        self::assertEquals(126501.27, $answer);

        //Test rounding down 126501.9228
        $answer = $interestClass->simpleInterest(100001.52, .053, 5, 2);
        self::assertEquals(126501.92, $answer);

    }


    public function testCompoundInterest()
    {

        $interestClass = new Interest();

        // Simple calculation
        $answer = $interestClass->compoundInterest('100', .03, 5, 12, 2);
        self::assertEquals(116.16, $answer);

        //// Simple calculation rounded to 5 places.
        $answer = $interestClass->compoundInterest('100', .03, 5, 12, 5);
        self::assertEquals(116.16168, $answer);
    }

    public function testCagr()
    {

        $interestClass = new Interest();

        // Simple calculation
        $answer = $interestClass->cagr(100, 200, 1, 2);
        self::assertEquals(1, $answer);


        $answer = $interestClass->cagr(100, 200, 10, 8);
        self::assertEquals(0.07177346, $answer);
    }

}