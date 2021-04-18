using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using turbocalc;
using System.Diagnostics;
namespace Profiling
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            CalculateTimes();
        }

        private void CalculateTimes()
        {
            string line;
            string[] input; 
            int volume = 0;
            List<int> data = new List<int>();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                input = line.Split(new char[] {' ', (char) 9, '\n'});
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

        private void CalcExpression(List<int> data, int volume)
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

        }
    }
}
