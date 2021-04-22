///
/// @file StandardDeviation.cs
/// <summary>
/// Standard deviation program
/// </summary>
///

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Turbocalc;
using System.Diagnostics;


/// <summary>
/// Profiling namespace
/// </summary>
namespace Profiling
{
    /// <summary>
    /// Standard deviation class
    /// </summary>
    class StandardDeviation
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        static void Main()
        {
            AllocConsole();
            CalculateTimes();
        }

        /// <summary>
        /// Reads input
        /// </summary>
        private static void CalculateTimes()
        {
            string line;
            string[] input;
            int volume = 0;
            List<int> data = new List<int>();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                input = line.Split(new char[] { ' ', (char)9, '\n' });
                volume += input.Length;
                foreach (var number in input)
                {
                    try
                    {
                        data.Add(Int32.Parse(number));
                    }
                    catch
                    {
                        volume--;
                    }
                }
            }

            CalcExpression(data, volume);
        }

        /// <summary>
        /// Calculates standard deviation
        /// </summary>
        /// <param name="data">List of numbers</param>
        /// <param name="volume">Size of numer list</param>
        private static void CalcExpression(List<int> data, int volume)
        {
            Stopwatch addition = new Stopwatch();
            Stopwatch multiply = new Stopwatch();
            Stopwatch divide = new Stopwatch();
            Stopwatch pow = new Stopwatch();
            Stopwatch sqrt = new Stopwatch();
            Stopwatch substract = new Stopwatch();

            double sum = 0;
            double expression = 0;
            double Arithmetic = 0;
            foreach (var number in data)
            {
                addition.Start();
                sum = Calculator.Add(sum, number);
                addition.Stop();
            }
            divide.Start();
            expression = Calculator.Divide(1, volume);
            divide.Stop();
            multiply.Start();
            Arithmetic = Calculator.Multiply(expression, sum);
            multiply.Stop();
            pow.Start();
            expression = Calculator.Power(Arithmetic, 2);
            pow.Stop();
            multiply.Start();
            expression = Calculator.Multiply(expression, volume);
            multiply.Stop();
            sum = 0;
            Arithmetic = 0;
            foreach (var number in data)
            {
                pow.Start();
                Arithmetic += Calculator.Power(number, 2);
                pow.Stop();

            }
            substract.Start();
            sum = Calculator.Subtract(Arithmetic, expression);
            substract.Stop();
            substract.Start();
            expression = Calculator.Subtract(volume, 1);
            substract.Stop();
            divide.Start();
            Arithmetic = Calculator.Divide(1, expression);
            divide.Stop();
            multiply.Start();
            sum = Calculator.Multiply(sum, Arithmetic);
            multiply.Stop();
            sqrt.Start();
            sum = Calculator.Root(sum, 2);
            sqrt.Stop();

            Console.WriteLine(sum);
            Console.WriteLine("Times are in nano seconds");
            Console.WriteLine("Time addition: {0}", addition.Elapsed.TotalMilliseconds * 1000000);
            Console.WriteLine("Time substract: {0}", substract.Elapsed.TotalMilliseconds * 1000000);
            Console.WriteLine("Time divide: {0}", divide.Elapsed.TotalMilliseconds * 1000000);
            Console.WriteLine("Time multiply: {0}", multiply.Elapsed.TotalMilliseconds * 1000000);
            Console.WriteLine("Time sqrt: {0}", sqrt.Elapsed.TotalMilliseconds * 1000000);
            Console.WriteLine("Time pow: {0}", pow.Elapsed.TotalMilliseconds * 1000000);

        } // CalcExpresion()

    } // class StandardDeviation
} // namespace Profiling
