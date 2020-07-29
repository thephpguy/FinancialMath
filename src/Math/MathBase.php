<?php
namespace FinancialMath\Math;


/**
 * This class is meant to contain common logic and math functions not specifically provided by php.
 *
 * Class MathBase
 * @package FinancialMath\Math
 */
abstract class MathBase
{

    /**
     * @param $number
     * @param int $precision
     * @return float|int
     */
    final public function roundUp($number, $precision = 2)
    {
        $precision++;
        $fig = (int) str_pad('1', $precision, '0');
        if($number >= 1 || $number <= -1)
        {
            if($number < 0) // Rounding for negative numbers
            {
                return (ceil($number * $fig *-1) / $fig) * -1;
            }
            return (ceil($number * $fig) / $fig);

        } else {

            if($number < 0) // Rounding for negative numbers
            {
                return (ceil(round($number * $fig * -1, $precision+2)) / $fig) * -1;
            }
            return (ceil(round($number * $fig, $precision+2)) / $fig);
        }
    }

    /**
     * @param $number
     * @param int $precision
     * @return float|int
     */
    final public function roundDown($number, $precision = 2)
    {
        $precision++;
        $fig = (int) str_pad('1', $precision, '0');
        if($number >= 1 || $number <= -1)
        {
            if($number < 0) // Rounding for negative numbers
            {
                return (floor($number * $fig *-1) / $fig) * -1;
            }
            return (floor($number * $fig) / $fig);

        } else {

            if($number < 0) // Rounding for negative numbers
            {
                return (floor(round($number * $fig * -1, $precision+2)) / $fig) * -1;
            }
            return (floor(round($number * $fig, $precision+2)) / $fig);
        }
    }

}