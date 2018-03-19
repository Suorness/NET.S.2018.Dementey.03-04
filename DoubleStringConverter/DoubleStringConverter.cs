using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleStringConverter
{
    /// <summary>
    /// Provides an extension method for double that converts double to a string
    /// </summary>
    public static class DoubleStringConverter
    {
        private const char TrueChar = '1';
        private const char FalseChar = '0';

        private const int ExponentOffset = 1023;
        private const int ExponentLength = 11;
        private const int MantissaLength = 52;
        private const int UnnormalExponentOffset = -1022;

        /// <summary>
        /// Converts double into string in binary format.
        /// </summary>
        /// <param name="value"> Double number to convert.</param>
        /// <returns></returns>
        public static string DoubleToString(this double value)
        {
            char sign = GetSignChar(value);

            if (sign == TrueChar)
            {
                value = Math.Abs(value);
            }

            int exponentLength = GetExponent(value);
            string exponent = GetBinaryExponent(exponentLength);
            string mantissa = GetMantissaBinary(value, exponentLength);

            return sign + exponent + mantissa;
        }

        private static char GetSignChar(double value)
        {
            var sign = FalseChar;

            if (value < 0 || double.IsNegativeInfinity(1 / value))
            {
                sign = TrueChar;
            }

            return sign;
        }

        private static string GetBinaryExponent(int exponent)
        {
            string result = IntToBinary(exponent);
            return result.Substring(result.Length - ExponentLength, ExponentLength);
        }

        private static int GetExponent(double value)
        {
            int grade = 0;

            double fraction = (value / Math.Pow(2, grade)) - 1;

            while ((fraction < 0) || (fraction >= 1))
            {
                if (fraction >= 1)
                {
                    grade++;
                }
                else
                {
                    grade--;
                }

                fraction = (value / Math.Pow(2, grade)) - 1;
            }

            grade += ExponentOffset;

            if (grade < 0)
            {
                grade = 0;
            }

            return grade;
        }

        private static string GetMantissaBinary(double value, int exponent)
        {
            exponent -= ExponentOffset;

            double fraction;

            if (exponent <= -ExponentOffset)
            {
                fraction = value / Math.Pow(2, UnnormalExponentOffset);
            }
            else
            {
                fraction = (value / Math.Pow(2, exponent)) - 1;
            }

            return FractionToBinary(fraction);
        }

        private static string FractionToBinary(double value)
        {
            var result = new StringBuilder();

            for (int i = 0; i < MantissaLength; i++)
            {
                var bit = FalseChar;
                value *= 2;
                if (value >= 1)
                {
                    bit = TrueChar;
                    value -= 1;
                }

                result.Append(bit);
            }

            return result.ToString();
        }

        private static string IntToBinary(long value)
        {
            string binary = string.Empty;
            long remainder;

            for (int i = 0; i < sizeof(long) * 8; i++)
            {
                remainder = value % 2;
                value /= 2;
                binary = remainder.ToString() + binary;
            }

            return binary;
        }
    }
}