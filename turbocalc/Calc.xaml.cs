using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
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
            display.Text += "0";
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
            display.Text += "1";
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
            display.Text += "2";
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
            display.Text += "3";
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
            display.Text += "4";
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
            display.Text += "5";
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
            display.Text += "6";
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
            display.Text += "7";
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
            display.Text += "8";
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
            display.Text += "9";
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
                display.Text += ".";
                _number[_counter] = ",";
                _counter++;
            }
        }

        private void TurboFunc(string op, string opSym, int weight)
        {
            if (_number[0] == "-" && _number[1] == null) return;

            if (_number[0] == null)
            {
                if (DataList.Last != null)
                {
                    if (DataList.Last.Value.Operation == "factorial")
                    {
                        FitInBox();
                        DataList.AddLast(new Data(0, op, weight, _bracketLevel));
                        display.Text += opSym;
                    }
                    else if (op == "minus")
                    {
                        FitInBox();
                        display.Text += opSym;
                        _number[_counter] = opSym;
                        _counter++;
                    }
                }
                else if (op == "minus")
                {
                    FitInBox();
                    display.Text += opSym;
                    _number[_counter] = opSym;
                    _counter++;
                }
                else if (op == "abs")
                {
                    FitInBox();
                    _count += 2;
                    display.Text += opSym;
                    if (_first)
                    {
                        _head = DataList.AddFirst(new Data(0, op, weight, _bracketLevel));
                        _first = false;
                    }

                    else
                        DataList.AddLast(new Data(0, op, weight, _bracketLevel));
                }

                return;
            }
            FitInBox();
            display.Text += opSym;
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number))));
            }
            DataList.AddLast(new Data(0, op, weight, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
        }


        /// <summary>
        /// Button + clicked, writes + to display, sets number to list and adds operation "plus" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            ///TODO: ošetřit _number[0] == "-" a number[1] == null; u všech operací
            ///TODO:_number[0] == null a pokud DataList.Last.Value.Operation == "factorial"; to samé jako Adds operation comment
            TurboFunc("plus", "+", 1);
        }
        /// <summary>
        /// Button - clicked, writes - to display, sets number to list and adds operation "minus" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == "-" && _number[1] == null) return;
            TurboFunc("minus", "-", 1);
        }

        /// <summary>
        /// Button ÷ clicked, writes ÷ to display, sets number to list and adds operation "divide" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("divide", "÷", 2);
        }

        /// <summary>
        /// Button × clicked, writes × to display, sets number to list and adds operation "multiply" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_multiply_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("multiply", "x", 2);
        }

        /// <summary>
        /// Button ! clicked, writes ! to display, sets number to list and adds operation "factorial" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_factorial_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("factorial", "!", 5);
        }

        /// <summary>
        /// Button √ clicked, writes √ to display, sets number to list and adds operation "root" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_root_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("root", "√", 3);
        }

        /// <summary>
        /// Button xⁿ clicked, writes xⁿ to display, sets number to list and adds operation "power" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_power_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("power", "xⁿ", 4);

        }

        /// <summary>
        /// Button abs clicked, writes "abs" to display, sets number to list and adds operation "abs" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_abs_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("abs", "abs", 5);

        }

        /// <summary>
        /// Button abs clicked, writes "mod" to display, sets number to list and adds operation "mod" to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_mod_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("mod", "%", 2);
        }
        /// <summary>
        /// Button ( clicked, highers bracketLevel and writes ( to display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_leftBracket_Click(object sender, RoutedEventArgs e)
        {
            FitInBox();
            display.Text += "(";
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
            display.Text += ")";
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
                    DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number)))); // Adds last number to list
                    LinkedListNode<Data> _pointer = DataList.Last;
                    LinkedListNode<Data> _max; // Max priority operation
                    while (DataList.Last != _head) // While list isn't only one node
                    {
                        _max = DataList.First.Next; // Second node == first operator
                        _pointer = DataList.First;
                        while (_pointer != DataList.Last) // Searching for max priority operator
                        {
                            if (_pointer.Value.Operation != "")
                            {
                                
                                if (_max.Value.BracketLevel <= _pointer.Value.BracketLevel)
                                {
                                    if (_max.Value.Weight < _pointer.Value.Weight)
                                    {
                                        _max = _pointer;
                                    }
                                }
                                
                            }

                            _pointer = _pointer.Next;
                        }
                        double a = 0, b = 0;
                        if (_max.Value.Operation != "abs") // Modulo only takes one number (after)
                        {
                            a = _max.Previous.Value.Number;
                        }
                        if (_max.Value.Operation != "factorial") // Factorial only takes one number (before)
                        {
                            b = _max.Next.Value.Number;
                        }
                        switch (_max.Value.Operation) // Decides what to do
                        {
                            case "plus":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Add(a,b))); // Adds new node with result
                                break;
                            case "minus":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Subtract(a, b))); // Adds new node with result
                                break;
                            case "divide":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Divide(a, b))); // Adds new node with result
                                break;
                            case "multiply":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Multiply(a, b))); // Adds new node with result
                                break;
                            case "power":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Power(a, (int)b))); // Adds new node with result
                                break;
                            case "root":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Root(b, (int)a))); // Adds new node with result
                                break;
                            case "factorial":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Factorial((int)a))); // Adds new node with result
                                break;
                            case "mod":
                                DataList.AddBefore(_max.Previous, new Data(Calculator.Mod(a, b))); // Adds new node with result
                                break;
                            case "abs":
                                DataList.AddBefore(_max, new Data(Calculator.Abs(b))); // Adds new node with result
                                break;
                        }
                        _head = DataList.First; // New head
                        display.Text = _max.Previous.Previous.Value.Number.ToString(CultureInfo.InvariantCulture); // New text on display
                        if (_max.Value.Operation != "abs")
                        {
                            DataList.Remove(_max.Previous); // Removes redundant node
                        }

                        if (_max.Value.Operation != "factorial")
                        {
                            DataList.Remove(_max.Next); // Removes redundant node
                        }
                        DataList.Remove(_max);
                    }

                    if (DataList.First != null)
                    {
                        display.Text = DataList.First.Value.Number.ToString(CultureInfo.InvariantCulture);
                    }
                }
            }

            // Tidying after operation
            _count = display.Text.Length; // How many characters are displayed
            ResetCounter(ref _counter, ref _number);
            string text = display.Text;
            display.Text = "";
            if (_count > 12) // Doesn't fit in display
            {
                for (int i = 0; i < 11; i++) // Trims text
                {
                    display.Text += text[i].ToString();
                    _number[i] = text[i].ToString();
                }

                int value = text[11] - '0';
                if (text[12] >= '5') value++; // Rounding up

                display.Text += value.ToString();
                _number[11] = value.ToString();
                
                _count = 12;
            }
            else
            {
                for (int i = 0; i < _count; i++)
                {
                    display.Text += text[i].ToString();
                    _number[i] = text[i].ToString();
                }
            }
            _counter = display.Text.Length; // New value of counter
            if (DataList.First != null)
            {
                DataList.RemoveFirst(); // Clears first node in list
            }
            _first = true; // First value will be entered
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
            if (e.Key == Key.Back) // enter, serves as =
            {
                Clear_Click(sender, e);
            }
            if (e.Key == Key.Delete) // enter, serves as =
            {
                Clear_Click(sender, e);
            }
        }
    }
}
