using System;

namespace turbocalc
{
    /// <summary>
    /// Math class for calculator
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds the two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>double a + b</returns>
        public static double Add(double a, double b)
        {
            return (double)((decimal)a + (decimal)b);
        }

        /// <summary>
        /// Subtracts the two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>double a - b</returns>
        public static double Subtract(double a, double b)
        {
            return (double)((decimal)a - (decimal)b);
        }

        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>double a / b</returns>
        public static double Divide(double a, double b)
        {
            if(b == 0)
                throw new ArgumentException("Division by zero.");
            return (double)((decimal)a / (decimal)b);
        }

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>double a * b</returns>
        public static double Multiply(double a, double b)
        {
            return (double)((decimal)a * (decimal)b);
        }

        /// <summary>
        /// The number 'x' to the power of 'n'
        /// </summary>
        /// <param name="x">Base</param>
        /// <param name="n">Exponent</param>
        /// <returns>
        ///     double x^n
        ///     Throws an exception if exponent is negative and base is 0
        /// </returns>
        public static double Power(double x, int n)
        {
            decimal sum = 1;
            bool negative = false;
            if (n == 0)
                return 1;
            if (n < 0)
                negative = true;
            //Division by zero
            if (x == 0 && n < 0)
                throw new ArgumentException("Can't do 0^-n -> Division by zero.");

            for (int i = 0; i < (negative ? -n : n); i++)
                sum *= (decimal)x;
            return negative ? (double)(1/sum) : (double)sum;
        }

        /// <summary>
        /// 'n'-th root of 'x' - x^(1/n)
        /// </summary>
        /// <param name="x">Number to make root of</param>
        /// <param name="n">Exponent</param>
        /// <returns>  
        ///     double root num^(1/n),
        ///     Throws an exception if root of number 'x' is not defined
        /// </returns>
        public static double Root(double x, int n)
        {
            //Division by zero
            if (x == 0 && n < 0)
                throw new ArgumentException("Can't do 0^-n -> Division by zero.");
            else if (x == 0)
                return 0;

            bool negative = false;
            //Negative number and odd-order root
            if (x < 0 && n % 2 != 0)
                negative = true;
            //Even-order root of negative number is not defined
            else if (x < 0 && n % 2 == 0)
                throw new ArgumentException("Even-order root of negative number is not defined.");

            //If root is 0
            if (n == 0)
                throw new ArgumentException("Can't do zero root of something.");
            else
                return negative ? -(Math.Pow(-x, 1.0 / n)) : (Math.Pow(x, 1.0 / n));
        }

        /// <summary>
        /// Makes factorial of a number 'x'
        /// </summary>
        /// <param name="x">Number to make factorial of</param>
        /// <returns>
        ///     int x!,
        ///     Returns -1 if 'x' is lesser than 0
        /// </returns>
        public static int Factorial(int x)
        {
            int sum = 1;
            //Factorial of 0
            if (x == 0)
                return 1;
            //Negative input
            else if (x < 0)
                return -1;
            else
            {
                for (int i = x; i > 0; i--)
                    sum *= i;
                return sum;
            }
        }

        /// <summary>
        /// Modulo of two numbers
        /// </summary>
        /// in C# a % b != a mod b (for negative numbers)
        /// In Math a mod b is remainder after Euclidean division
        /// The remainder in Euclidean division is always positive
        /// Examples:  10 mod 3 = 1
        ///            10 mod -3 = 1
        ///           -10 mod 3 = 2
        ///           -10 mod -3 = 2
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>
        ///     int a mod b
        ///     Throws an exception if dividing by 0
        /// </returns>
        public static double Mod(double a, double b) 
        {
            if (b == 0)
                throw new ArgumentException("Division by zero.");
            var mod = a % b;
            if (mod < 0)
                mod = (b < 0) ? mod - b : mod + b;
            return mod;
        }

        /// <summary> 
        /// Absolute of the number
        /// </summary>
        /// <param name="x">Number</param>
        /// <returns>double |x|</returns>
        public static double Abs(double x)
        {
            if (x < 0)
                return -x;
            else
                return x;
        }
    }
}