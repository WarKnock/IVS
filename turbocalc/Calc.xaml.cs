using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace turbocalc
{
    /// <summary>
    /// Interaction logic for Calc.xaml
    /// </summary>
    public partial class Calc : Window
    {
        private string[] number = new string[100];
        private int counter = 0;
        private int count = 0;
        private int bracketLevel = 30;
        
        public struct Data
        {
           
            public Data(double number = 0, string operation = "", int weigth = 0, int bracketLevel = 0)
            {
                Number = number;
                Operation = operation;
                Weigth = weigth;
                BracketLevel = bracketLevel;
            }

            public double Number { get; set; }
            public string Operation { get; set; }
            public int Weigth { get; set; }
            public int BracketLevel { get; set; }
        }

        public LinkedList<Data> dataList = new LinkedList<Data>();
        private LinkedListNode<Data> pointer;
        private LinkedListNode<Data> head;

        private bool first = true;



        public Calc()
        {
            InitializeComponent();
        }

        private void fitInBox()
        {
            if (count < 12) count++;
            else
            {
                string text = display.Text;
                display.Text = text[1].ToString();
                for (int i = 2; i < count; i++)
                {
                    display.Text = display.Text + text[i].ToString();
                }
            }
        }

        void resetCounter(ref int counter, ref string[] number)
        {
            for (int i = 0; i < counter; i++)
            {
                number[i] = null;
            }

            counter = 0;
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                fitInBox();
                display.Text = display.Text + "0";
                number[counter] = "0";
                counter++;
            }
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "1";
            number[counter] = "1";
            counter++;
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "2";
            number[counter] = "2";
            counter++;
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "3";
            number[counter] = "3";
            counter++;
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "4";
            number[counter] = "4";
            counter++;
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "5";
            number[counter] = "5";
            counter++;
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "6";
            number[counter] = "6";
            counter++;
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "7";
            number[counter] = "7";
            counter++;
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "8";
            number[counter] = "8";
            counter++;
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "9";
            number[counter] = "9";
            counter++;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            display.Text = "";
            while (dataList.Last != head)
            {
                dataList.Remove(dataList.Last);
            }
            dataList.Remove(dataList.Last);
            resetCounter(ref counter, ref  number);
            first = true;
        }

        private void Button_point_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                fitInBox();
                display.Text = display.Text + ".";
                number[counter] = ",";
                counter++;
            }
        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                display.Text = display.Text + "+";
                if (first)
                {
                    head = dataList.AddFirst(new Data(Convert.ToDouble(string.Concat(number))));
                    first = false;
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                }
                dataList.AddLast(new Data(0, "plus", 1, bracketLevel));
                resetCounter(ref counter, ref number);
            }
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                display.Text = display.Text + "-";
                if (first)
                {
                    head = dataList.AddFirst(new Data(Convert.ToDouble(string.Concat(number))));
                    first = false;
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                }
                dataList.AddLast(new Data(0, "minus", 1, bracketLevel));
                resetCounter(ref counter, ref number);
            }
        }

        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                display.Text = display.Text + "÷";
                if (first)
                {
                    head = dataList.AddFirst(new Data(Convert.ToDouble(string.Concat(number))));
                    first = false;
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                }
                dataList.AddLast(new Data(0, "divide", 2, bracketLevel));
                resetCounter(ref counter, ref number);
            }
        }

        private void Button_multiply_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                display.Text = display.Text + "×";
                if (first)
                {
                    head = dataList.AddFirst(new Data(Convert.ToDouble(string.Concat(number))));
                    first = false;
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                }
                dataList.AddLast(new Data(0, "multiply", 2, bracketLevel));
                resetCounter(ref counter, ref number);
            }
        }

        private void Button_factorial_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                display.Text = display.Text + "!";
                if (first)
                {
                    head = dataList.AddFirst(new Data(Convert.ToDouble(string.Concat(number))));
                    first = false;
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                }
                dataList.AddLast(new Data(0, "factorial", 5, bracketLevel));
                resetCounter(ref counter, ref number);
            }
        }

        private void Button_root_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                display.Text = display.Text + "√";
                if (first)
                {
                    head = dataList.AddFirst(new Data(Convert.ToDouble(string.Concat(number))));
                    first = false;
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                }
                dataList.AddLast(new Data(0, "root", 3, bracketLevel));
                resetCounter(ref counter, ref number);
            }
        }

        private void Button_power_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                display.Text = display.Text + "xⁿ";
                if (first)
                {
                    head = dataList.AddFirst(new Data(Convert.ToDouble(string.Concat(number))));
                    first = false;
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                }
                dataList.AddLast(new Data(0, "power", 4, bracketLevel));
                resetCounter(ref counter, ref number);
            }
        }

        private void Button_leftBracket_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "(";
            bracketLevel++;
        }

        private void Button_rightBracket_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + ")";
            bracketLevel--;
        }

        private void Button_calculate_Click(object sender, RoutedEventArgs e)
        {
            if (number[0] != null)
            {
                fitInBox();
                if (first)
                {
                    display.Text = string.Concat(number);
                }
                else
                {
                    dataList.AddLast(new Data(Convert.ToDouble(string.Concat(number))));
                    display.Text = (head.Value.Number + dataList.Last.Value.Number).ToString();
                }
            }

            count = display.Text.Length;1
        }

        private void Key_press(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Divide)
            {
                Button_divide_Click(sender, e);
            }
            if (e.Key == Key.Multiply)
            {
                Button_multiply_Click(sender, e);
            }
            if (e.Key == Key.Decimal)
            {
                Button_point_Click(sender, e);
            }
            if (e.Key == Key.OemComma)
            {
                Button_point_Click(sender, e);
            }
            if (e.Key == Key.OemOpenBrackets)
            {
                Button_leftBracket_Click(sender, e);
            }
            if (e.Key == Key.OemCloseBrackets)
            {
                Button_rightBracket_Click(sender, e);
            }
            if (e.Key == Key.Enter)
            {
                Button_calculate_Click(sender, e);
            }


        }
    }
}
