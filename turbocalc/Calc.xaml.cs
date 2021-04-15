﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        private string[] _number = new string[100]; // Array of strings for number
        private int _counter = 0; // Counter for characters in number
        private int _count = 0; // Count of characters in textBlock
        private int _bracketLevel = 30; // 30 to start somewhere in the middle(can go up or down)
        
        /// <summary>
        /// Structure containing data - number or operators of calculation
        /// </summary>
        public struct Data
        {
           /// <summary>
           /// Constructor
           /// </summary>
           /// <param name="number">double number</param>
           /// <param name="operation">name of operator(plus, minus,...)</param>
           /// <param name="weight">weight of operator, higher number means higher priority</param>
           /// <param name="bracketLevel">bracket level of operator, higher number means higher priority(even if operator has higher weight)</param>
            public Data(double number = 0, string operation = "", int weight = 0, int bracketLevel = 0)
            {
                Number = number;
                Operation = operation;
                Weight = weight;
                BracketLevel = bracketLevel;
            }

            public double Number { get; set; } 
            public string Operation { get; set; } // Plus, minus, multiply, divide, root, power, factorial
            public int Weight { get; set; }
            public int BracketLevel { get; set; }
        }

        /// <summary>
        /// Doubly linked list containing data structures.
        /// </summary>
        public LinkedList<Data> DataList = new LinkedList<Data>();
        private LinkedListNode<Data> _head; /// Head of dataList

        private bool _first = true; // Determines first insertion into list


        public Calc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Erases the most left character in textBlock to make a space for new character.
        /// </summary>
        private void FitInBox()
        {
            if (_count < 12) _count++; // textBlock is not full yet
            else // too much content in textBlock
            {
                string text = display.Text; // Temp string
                display.Text = text[1].ToString();
                for (int i = 2; i < _count; i++) // moving chars to new position
                {
                    display.Text += text[i].ToString();
                }
            }
        }

        /// <summary>
        /// Resets counter of letters in number
        /// </summary>
        /// <param name="counter"> counter of letters in number</param>
        /// <param name="number"> string for number </param>
        private static void ResetCounter(ref int counter, ref string[] number)
        {
            for (int i = 0; i < counter; i++)
            {
                number[i] = null; // Resets number
            }

            counter = 0; // Resets counter
        }

        /// <summary>
        /// Button 0 clicked, writes 0 to display and ads 0 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) return; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "0";
            _number[_counter] = "0";
            _counter++;
        }

        /// <summary>
        /// Button 1 clicked, writes 1 to display and ads 1 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "1";
            _number[_counter] = "1";
            _counter++;
        }

        /// <summary>
        /// Button 2 clicked, writes 2 to display and ads 2 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "2";
            _number[_counter] = "2";
            _counter++;
        }

        /// <summary>
        /// Button 3 clicked, writes 3 to display and ads 3 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "3";
            _number[_counter] = "3";
            _counter++;
        }

        /// <summary>
        /// Button 4 clicked, writes 4 to display and ads 4 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "4";
            _number[_counter] = "4";
            _counter++;
        }

        /// <summary>
        /// Button 5 clicked, writes 5 to display and ads 5 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "5";
            _number[_counter] = "5";
            _counter++;
        }

        /// <summary>
        /// Button 6 clicked, writes 6 to display and ads 6 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "6";
            _number[_counter] = "6";
            _counter++;
        }

        /// <summary>
        /// Button 7 clicked, writes 7 to display and ads 7 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "7";
            _number[_counter] = "7";
            _counter++;
        }

        /// <summary>
        /// Button 8 clicked, writes 8 to display and ads 8 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "8";
            _number[_counter] = "8";
            _counter++;
        }

        /// <summary>
        /// Button 9 clicked, writes 9 to display and ads 9 to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            if ((_counter == 1) && (_number[0] == "0")) _counter--; // Prevents numbers like 000000001
            FitInBox();
            display.Text = display.Text + "9";
            _number[_counter] = "9";
            _counter++;
        }

        /// <summary>
        /// Button clear clicked, resets everything and erases display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _count = 0;
            display.Text = "";
            if (DataList.First != null) // Avoids error from deleting null
            {
                while (DataList.Last != _head) // Deletes dataList
                {
                    DataList.Remove(DataList.Last);
                }
                DataList.Remove(DataList.Last);
            }
            ResetCounter(ref _counter, ref  _number); // Resets counter
            _first = true;  // Next number will be first in dataList(which is empty)
        }

        /// <summary>
        /// Button . clicked, writes , to display and , to number string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_point_Click(object sender, RoutedEventArgs e)
        {
            if (_counter > 0)
            {
                FitInBox();
                display.Text = display.Text + ".";
                _number[_counter] = ",";
                _counter++;
            }
        }

        /// <summary>
        /// Button + clicked, writes + to display, sets number to list and adds operation "plus" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null) return;
            FitInBox();
            display.Text = display.Text + "+";
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
            }
            DataList.AddLast(new Data(0, "plus", 1, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }

        /// <summary>
        /// Button - clicked, writes - to display, sets number to list and adds operation "minus" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null) return;
            FitInBox();
            display.Text = display.Text + "-";
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
            }
            DataList.AddLast(new Data(0, "minus", 1, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }

        /// <summary>
        /// Button ÷ clicked, writes ÷ to display, sets number to list and adds operation "divide" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null) return;
            FitInBox();
            display.Text = display.Text + "÷";
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
            }
            DataList.AddLast(new Data(0, "divide", 2, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }

        /// <summary>
        /// Button × clicked, writes × to display, sets number to list and adds operation "multiply" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_multiply_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null) return;
            FitInBox();
            display.Text = display.Text + "×";
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
            }
            DataList.AddLast(new Data(0, "multiply", 2, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }

        /// <summary>
        /// Button ! clicked, writes ! to display, sets number to list and adds operation "factorial" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_factorial_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null) return;
            FitInBox();
            display.Text = display.Text + "!";
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
            }
            DataList.AddLast(new Data(0, "factorial", 5, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }

        /// <summary>
        /// Button √ clicked, writes √ to display, sets number to list and adds operation "root" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_root_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null) return;
            FitInBox();
            display.Text = display.Text + "√";
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number)))); 
            }
            DataList.AddLast(new Data(0, "root", 3, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }

        /// <summary>
        /// Button xⁿ clicked, writes xⁿ to display, sets number to list and adds operation "power" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_power_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null) return;
            FitInBox();
            display.Text = display.Text + "xⁿ";
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
            }
            DataList.AddLast(new Data(0, "power", 4, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }

        /// <summary>
        /// Button ( clicked, highers bracketLevel and writes ( to display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_leftBracket_Click(object sender, RoutedEventArgs e)
        {
            FitInBox();
            display.Text = display.Text + "(";
            _bracketLevel++;
        }

        /// <summary>
        /// Button ) clicked, lowers bracketLevel and writes ) to display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_rightBracket_Click(object sender, RoutedEventArgs e)
        {
            FitInBox();
            display.Text = display.Text + ")";
            _bracketLevel--;
        }


        /// <summary>
        /// Button = clicked, calculates result and writes it in display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_calculate_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] != null)
            {
                FitInBox();
                if (_first) // Only one number entered and no operation - rewrites the number
                {
                    display.Text = string.Concat(_number).Replace(',', '.');
                }
                else // Main brain
                {
                    DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
                    if (DataList.Last != null)
                    {
                        display.Text = (_head.Value.Number + DataList.Last.Value.Number).ToString(CultureInfo.InvariantCulture);
                    }
                }
            }
            _count = display.Text.Length; // How many characters are displayed
        }

        /// <summary>
        /// Catches key presses and links them to button functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (e.Key == Key.Decimal) // point
            {
                Button_point_Click(sender, e);
            }
            if (e.Key == Key.OemComma) // point
            {
                Button_point_Click(sender, e);
            }
            if (e.Key == Key.OemOpenBrackets) // (
            {
                Button_leftBracket_Click(sender, e);
            }
            if (e.Key == Key.OemCloseBrackets) // )
            {
                Button_rightBracket_Click(sender, e);
            }
            if (e.Key == Key.Enter) // enter, serves as =
            {
                Button_calculate_Click(sender, e);
            }
        }
    }
}
