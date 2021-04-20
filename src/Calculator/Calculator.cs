///
/// @file Calculator.cs
///

using System;

namespace Turbocalc
{
    /// <summary>
    /// Math class for the main application
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Returns the sum of the two numbers</returns>
        public static double Add(double a, double b)
        {
            return (double)((decimal)a + (decimal)b);
        } // Add()

        /// <summary>
        /// Subtracts two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>a - b</returns>
        public static double Subtract(double a, double b)
        {
            return (double)((decimal)a - (decimal)b);
        } // Subtract()

        /// <summary>
        /// Divides the two numbers
        /// </summary>
        /// <param name="a">Divident</param>
        /// <param name="b">Divisor</param>
        /// <returns>Returns the quotient of the two numbers</returns>
        public static double Divide(double a, double b)
        {
            if(b == 0) //Division by zero
                throw new ArgumentException("Division by zero.");
            return (double)((decimal)a / (decimal)b);
        } // Divide()

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Returns the product of the two numbers</returns>
        public static double Multiply(double a, double b)
        {
            return (double)((decimal)a * (decimal)b);
        } // Multiply()

        /// <summary>
        /// Exponentiates a number
        /// </summary>
        /// <param name="x">Base</param>
        /// <param name="n">Exponent</param>
        /// <returns>Returns the base to the power of exponent</returns>
        public static double Power(double x, int n)
        {
            decimal sum = 1;
            bool negative = false;

            if (n == 0) //Exponent is 0
                return 1;
            if (n < 0) //Exponent is negative
                negative = true;
            if (x == 0 && n < 0) //Division by zero
                throw new ArgumentException("Division by zero.");

            for (int i = 0; i < (negative ? -n : n); i++)
                sum *= (decimal)x;

            return negative ? (double)(1/sum) : (double)sum;
        } // Power()

        /// <summary>
        /// N-th root of a number
        /// </summary>
        /// <param name="x">Number to make root of</param>
        /// <param name="n">Degree of the root</param>
        /// <returns>Returns the N-th root of the number</returns>
        public static double Root(double x, int n)
        {
            if (x == 0 && n < 0) //Division by zero
                throw new ArgumentException("Division by zero.");
            else if (x == 0) //Root of 0
                return 0;

            bool negative = false;
            if (x < 0 && n % 2 != 0) //Negative number and odd-order root
                negative = true;
            else if (x < 0 && n % 2 == 0) //Even-order root of negative number is not defined
                throw new ArgumentException("Even-order root of negative number is not defined.");

            if (n == 0) //If the degree of the root is 0
                throw new ArgumentException("A root of degree 0 is not defined.");
            else
                return negative ? -(Math.Pow(-x, 1.0 / n)) : (Math.Pow(x, 1.0 / n));
        } // Root()

        /// <summary>
        /// Makes factorial of a number
        /// </summary>
        /// <param name="x">Number to make factorial of</param>
        /// <returns>Returns a factorial of the number</returns>
        public static int Factorial(int x)
        {
            int sum = 1;
            
            if (x == 0) //Factorial of 0
                return 1;
            if (x < 0) //Negative number
                return -1;

            for (int i = x; i > 0; i--)
                sum *= i;

            return sum;
        }

        /// <summary>
        /// Gets the remainder from dividing two numbers
        /// </summary>
        /// <param name="a">Divident</param>
        /// <param name="b">Divisor</param>
        /// <returns>Returns the remainder of the divident divided by the divisor</returns>
        public static double Mod(double a, double b) 
        {
            if (b == 0) //Division by zero
                throw new ArgumentException("Division by zero.");

            decimal mod = (decimal)a % (decimal)b;
            if (mod < 0) //Mod definition is different for negative numbers
                mod = (b < 0) ? mod - (decimal)b : mod + (decimal)b;
            return (double)mod;
        } // Mod()

        /// <summary> 
        /// Makes absolute of a number
        /// </summary>
        /// <param name="x">Number</param>
        /// <returns>Returns the absolute of the number</returns>
        public static double Abs(double x)
        {
            if (x < 0)
                return -x;
            else
                return x;
        } // Abs()
    } //class Calculator
}
