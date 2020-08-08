<?php
namespace FinancialMath\Math;
use PHPUnit\Framework\TestCase;

class TestForMathBase extends MathBase
{
    //Blank class for testing MathBase.
}

final class MathBaseTest extends TestCase
{

    public function testRoundUp()
    {
        $mathBaseClass = new TestForMathBase();

        $result = $mathBaseClass->roundUp(10.333, 2);
        self::assertEquals(10.34, $result);

        $result = $mathBaseClass->roundUp(10.331, 2);
        self::assertEquals(10.34, $result);

        $result = $mathBaseClass->roundUp(10.330, 2);
        self::assertEquals(10.33, $result);

        $result = $mathBaseClass->roundUp(10.33, 2);
        self::assertEquals(10.33, $result);

        $result = $mathBaseClass->roundUp(10.330, 3);
        self::assertEquals(10.330, $result);

        $result = $mathBaseClass->roundUp(10.3331, 3);
        self::assertEquals(10.334, $result);

        $result = $mathBaseClass->roundUp(10.111111111111, 11);
        self::assertEquals(10.11111111112, $result);

        $result = $mathBaseClass->roundUp(10.991, 2);
        self::assertEquals(11, $result);

        $result = $mathBaseClass->roundUp(10.991, 1);
        self::assertEquals(11, $result);
    }

    public function testRoundDown()
    {
        $mathBaseClass = new TestForMathBase();

        $result = $mathBaseClass->roundDown(10.333, 2);
        self::assertEquals(10.33, $result);

        $result = $mathBaseClass->roundDown(10.014, 2);
        self::assertEquals(10.01, $result);
    }


    public function testDecimalToPercent()
    {
        $mathBaseClass = new TestForMathBase();

        $result = $mathBaseClass->decimalToPercent(.02);
        self::assertEquals(2, $result);

        $result = $mathBaseClass->decimalToPercent(1.02);
        self::assertEquals(102, $result);

        $result = $mathBaseClass->decimalToPercent(.50);
        self::assertEquals(50, $result);
    }


    public function testPercentToDecimal()
    {
        $mathBaseClass = new TestForMathBase();

        $result = $mathBaseClass->percentToDecimal(2);
        self::assertEquals(.02, $result);

        $result = $mathBaseClass->percentToDecimal(100);
        self::assertEquals(1, $result);
    }



    public function testSanitizeInteger()
    {
        $mathBaseClass = new TestForMathBase();

        $result = $mathBaseClass->sanitizeInteger('01');
        self::assertEquals(1, $result);

        $result = $mathBaseClass->sanitizeInteger('asdf01asdfasd');
        self::assertEquals(1, $result);

        $result = $mathBaseClass->sanitizeInteger(15);
        self::assertEquals(15, $result);

        $result = $mathBaseClass->sanitizeInteger(15.12);
        self::assertEquals(1512, $result);

        $result = $mathBaseClass->sanitizeInteger(.12);
        self::assertEquals(12, $result);

    }


    public function testSanitizeFloat()
    {
        $mathBaseClass = new TestForMathBase();

        $result = $mathBaseClass->sanitizeFloat(1.19);
        self::assertEquals(1.19, $result);

        $result = $mathBaseClass->sanitizeFloat('15.18');
        self::assertEquals(15.18, $result);

        $result = $mathBaseClass->sanitizeFloat(15.18);
        self::assertEquals(15.18, $result);

        $result = $mathBaseClass->sanitizeFloat(.12);
        self::assertEquals(0.12, $result);

    }


}