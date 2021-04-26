///
/// @file Calc.xaml.cs
/// <summary>
/// Main application
/// </summary>
///

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

/// <summary>
/// Calculator namespace
/// </summary>
namespace Turbocalc
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
        private bool _pointNumber = false; // If point was entered
        private bool _rBracket = false;
        private const int _displayMaxNumber = 35;

        /// <summary>
        /// Initialization
        /// </summary>
        public Calc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Erases the most left character in textBlock to make a space for new character
        /// </summary>
        private void FitInBox()
        {
            if (_count < _displayMaxNumber) _count++; // textBlock is not full yet
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
        /// Writes help when bad combination is entered
        /// </summary>
        /// <param name="choice">Last operator</param>
        private void WriteHelp(string choice)
        {
            switch (choice)
            {
                case "plus":
                    warnings.Content = "Použití operátoru + :\n\ta + b";
                    break;
                case "minus":
                    warnings.Content = "Použití operátoru - :\n\ta - b ; -n";
                    break;
                case "divide":
                    warnings.Content = "Použití operátoru ÷ :\n\ta ÷ b";
                    break;
                case "multiply":
                    warnings.Content = "Použití operátoru x :\n\ta x b";
                    break;
                case "power":
                    warnings.Content = "Použití operátoru xⁿ :\n\tčíslo(x) ^ exponent(n)";
                    break;
                case "root":
                    warnings.Content = "Použití operátoru √ : a√b\na -> implicitne = 2 -> druhá odmocnina";
                    break;
                case "factorial":
                    warnings.Content = "Použití operátoru ! : a!";
                    break;
                case "abs":
                    warnings.Content = "Použití operátoru abs : abs(x)\n\tabs ( výpočet )";
                    break;
                case "mod":
                    warnings.Content = "Použití operátoru mod :\n\ta % b";
                    break;
                case "point":
                    warnings.Content = "Použití desetinné čárky(tečky) : a,b\nPři nezadání čísla a bude doplněna 0 před";
                    break;
                case "lBracket":
                    warnings.Content = "Použití ( :\n\toperátor ( výraz";
                    break;
                case "rBracket":
                    warnings.Content = "Použití ) :\n\tvýraz ) operátor";
                    break;
                case "pair":
                    warnings.Content = "Některé závorky nebyly řádně ukončeny.\nChybějící závorky byly doplněny před a za příklad.";
                    break;
                case "equal":
                    warnings.Content = "Použití = :\n\tvýraz =";
                    break;
                case "tooLong":
                    warnings.Content = "Zadané číslo je příliš dlouhé.\nMaximální počet znaků v čísle je 100.";
                    break;
                case "outOfDouble":
                    warnings.Content = "Výsledek daného příkladu je příliš velký.\nTak velké čísla turbocalc nepodporuje.";
                    break;
            }
        } // WriteHelp()

        /// <summary>
        /// Function when number is clicked
        /// </summary>
        /// <param name="number">Which number was clicked</param>
        private void NumberClicked(string number)
        {
            if (_rBracket) // number can't be after ) -> 1)7 cause it will result in storing number 17
            {
                WriteHelp("rBracket");
                return;
            }
            if (_counter >= 100)
            {
                WriteHelp("tooLong");
                return;
            }
            if ((_counter == 1) && (_number[0] == "0"))
            {
                if (number == "0") return; // Prevents numbers like 000000001
                else _counter--; // Storing number without 0 -> 01 as 1 
            }
            FitInBox();
            display.Text += number;
            _number[_counter] = number;
            _counter++; // next number
        } // NumberClicked()

        /// <summary>
        /// Resets counter of letters in number
        /// </summary>
        /// <param name="counter">Counter of letters in number</param>
        /// <param name="number">String for number</param>
        private static void ResetCounter(ref int counter, ref string[] number)
        {
            for (int i = 0; i < counter; i++)
            {
                number[i] = null; // Resets number
            }

            counter = 0; // Resets counter
        } // ResetCounter()

        /// <summary>
        /// Button 0 clicked, writes 0 to display and ads 0 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("0");
        } // Button_0_Click()

        /// <summary>
        /// Button 1 clicked, writes 1 to display and ads 1 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("1");
        } // Button_1_Click()

        /// <summary>
        /// Button 2 clicked, writes 2 to display and ads 2 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("2");
        } // Button_2_Click()

        /// <summary>
        /// Button 3 clicked, writes 3 to display and ads 3 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("3");
        } // Button_3_Click()

        /// <summary>
        /// Button 4 clicked, writes 4 to display and ads 4 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("4");
        } // Button_4_Click()

        /// <summary>
        /// Button 5 clicked, writes 5 to display and ads 5 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("5");
        } // Button_5_Click()

        /// <summary>
        /// Button 6 clicked, writes 6 to display and ads 6 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("6");
        } // Button_6_Click()

        /// <summary>
        /// Button 7 clicked, writes 7 to display and ads 7 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("7");
        } // Button_7_Click()

        /// <summary>
        /// Button 8 clicked, writes 8 to display and ads 8 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("8");
        } // Button_8_Click()

        /// <summary>
        /// Button 9 clicked, writes 9 to display and ads 9 to number
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            NumberClicked("9");
        } // Button_9_Click()

        /// <summary>
        /// Button clear clicked, resets everything and erases display
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
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
            _rBracket = false; // Resets right bracket
            _pointNumber = false; // Resets point number
        } // Clear_Click()

        /// <summary>
        /// Button . clicked, writes , to display and , to number string
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_point_Click(object sender, RoutedEventArgs e)
        {
            if (_rBracket) // Can't be ).
            {
                WriteHelp("rBracket");
                return;
            }
            if (_pointNumber) // Can't be 0..
            {
                WriteHelp("point");
                return;
            }
            if (_counter == 0) // if point is entered first, then adds 0 before point -> 0,
            {
                FitInBox();
                display.Text += "0";
                _number[_counter] = "0";
                _counter++;
            }
            FitInBox();
            display.Text += ".";
            _number[_counter] = ",";
            _counter++;
            _pointNumber = true;
        } // Button_point_Click()

        /// <summary>
        /// Displays operations on calculator
        /// </summary>
        /// <param name="op">Operator</param>
        /// <param name="opSym"></param>
        /// <param name="weight">Weight of operator</param>
        private void TurboFunc(string op, string opSym, int weight)
        {
            if (_number[0] == "-" && _number[1] == null) // if the expression starts with "-"
            {                                            // and isn't followed by a number
                WriteHelp(op);                           // Write Help for op
                return;
            }


            if (_number[0] == null)// start of expression
            {
                if (DataList.Last != null)// check if datalist is unempty (some operators can't be first)
                {
                    if (DataList.Last.Value.Operation == "factorial") 
                    {
                        FitInBox();
                        DataList.AddLast(new Data(0, op, weight, _bracketLevel)); // every operation is represented by "0"
                        display.Text += opSym;
                    }
                    else if (op == "minus")
                    {
                        FitInBox();
                        display.Text += opSym;      // writes text on display
                        _number[_counter] = opSym;  // adds operand to string
                        _counter++;                 
                    }
                    else if (op == "abs")
                    {
                        if (DataList.Last.Value.Operation == "" || DataList.Last.Value.Operation == "abs")
                        {
                            WriteHelp(op);
                            return;
                        }
                        FitInBox();
                        display.Text += "a"; 
                        FitInBox();
                        display.Text += "b";
                        FitInBox();
                        display.Text += "s";
                        DataList.AddLast(new Data(0, op, weight, _bracketLevel));
                        _first = false; // checks if operator is first
                    }
                    else if (op == "root")
                    {
                        FitInBox();
                        display.Text += opSym;
                        DataList.AddLast(new Data(2)); // implicit root is of 2
                        DataList.AddLast(new Data(0, op, weight, _bracketLevel));
                    }
                    else
                    {
                        WriteHelp(op);
                        return;
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
                    if (_first)
                    {
                        _head = DataList.AddFirst(new Data(0, op, weight, _bracketLevel));
                        _first = false;
                    }

                    else if (DataList.Last.Value.Operation == "")
                    {
                        DataList.AddLast(new Data(0, op, weight, _bracketLevel));
                    }
                    else
                    {
                        WriteHelp(op);
                        return;
                    }
                    FitInBox();
                    display.Text += "a";
                    FitInBox();
                    display.Text += "b";
                    FitInBox();
                    display.Text += "s";
                }
                else if (op == "root")
                {
                    FitInBox();
                    display.Text += opSym;
                    _head = DataList.AddFirst(new Data(2));
                    _first = false;
                    DataList.AddLast(new Data(0, op, weight, _bracketLevel));
                }
                else
                {
                    WriteHelp(op);
                    return;
                }

                _pointNumber = false; // resets decimal number
                _rBracket = false;    // resets closing bracket
                warnings.Content = "";
                return;
            }

            if (op == "abs")
            {
                WriteHelp(op);
                return;
            }
            FitInBox();
            display.Text += opSym; // for any other operator
            if (_first) // Adds head to list
            {
                _head = DataList.AddFirst(new Data(Convert.ToDouble(string.Concat(_number).Replace('.', ','))));
                _first = false;
            }
            else // Adds number to last position in list
            {
                DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number).Replace('.', ','))));
            }
            DataList.AddLast(new Data(0, op, weight, _bracketLevel)); // Adds operation
            ResetCounter(ref _counter, ref _number);
            _pointNumber = false;
            _rBracket = false;
            warnings.Content = ""; // Resets warning
        } // TurboFunc()

        /// <summary>
        /// Button + clicked, writes + to display, sets number to list and adds operation "plus" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("plus", "+", 1);
        } // Button_plus_Click()

        /// <summary>
        /// Button - clicked, writes - to display, sets number to list and adds operation "minus" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == "-" && _number[1] == null) return;
            TurboFunc("minus", "-", 1);
        } // Button_minus_Click()

        /// <summary>
        /// Button ÷ clicked, writes ÷ to display, sets number to list and adds operation "divide" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("divide", "÷", 2);
        } // Button_divide_Click()

        /// <summary>
        /// Button × clicked, writes × to display, sets number to list and adds operation "multiply" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_multiply_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("multiply", "x", 2);
        } // Button_multiply_Click()

        /// <summary>
        /// Button ! clicked, writes ! to display, sets number to list and adds operation "factorial" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_factorial_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("factorial", "!", 5);
        } // Button_factorial_Click()

        /// <summary>
        /// Button √ clicked, writes √ to display, sets number to list and adds operation "root" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_root_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("root", "√", 3);
        } // Button_root_Click()

        /// <summary>
        /// Button xⁿ clicked, writes xⁿ to display, sets number to list and adds operation "power" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_power_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("power", "^", 4);
        } // Button_power_Click()

        /// <summary>
        /// Button abs clicked, writes "abs" to display, sets number to list and adds operation "abs" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_abs_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("abs", "abs", 5);
        } // Button_abs_Click()

        /// <summary>
        /// Button abs clicked, writes "mod" to display, sets number to list and adds operation "mod" to list
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_mod_Click(object sender, RoutedEventArgs e)
        {
            TurboFunc("mod", "%", 2);
        } // Button_mod_Click()

        /// <summary>
        /// Button ( clicked, highers bracketLevel and writes ( to display
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_leftBracket_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] == null)
            {
                FitInBox();
                display.Text += "(";
                _bracketLevel++;
            }
            else
            {
                WriteHelp("lBracket");
            }
        } // Button_leftBracket_Click()

        /// <summary>
        /// Button ) clicked, lowers bracketLevel and writes ) to display
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_rightBracket_Click(object sender, RoutedEventArgs e)
        {
            if (_number[0] != null)
            {
                FitInBox();
                display.Text += ")";
                _bracketLevel--;
                _rBracket = true;
            }
            else
            {
                WriteHelp("rBracket");
            }
        } // Button_rightBracket_Click()

        /// <summary>
        /// Button = clicked, calculates result and writes it in display
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Event data associated with a routed event</param>
        private void Button_calculate_Click(object sender, RoutedEventArgs e)
        {
            bool end = false;
            if (_number[0] != null || DataList.Last.Value.Operation == "factorial")
            {
                FitInBox();
                if (_first) // Only one number entered and no operation - rewrites the number
                {
                    display.Text = string.Concat(_number).Replace(',', '.');
                }
                else // Main brain
                {
                    if(DataList.Last.Value.Operation != "factorial")
                        DataList.AddLast(new Data(Convert.ToDouble(string.Concat(_number).Replace('.', ',')))); // Adds last number to list
                    LinkedListNode<Data> _pointer = DataList.Last;
                    LinkedListNode<Data> _max; // Max priority operation
                    while (DataList.Last != _head) // While list isn't only one node
                    {
                        _max = DataList.First.Next; // Second node == first operator
                        _pointer = DataList.First;
                        while (_pointer != null) // Searching for max priority operator
                        {
                            if (_pointer.Value.Operation != "")
                            {
                                
                                if (_max.Value.BracketLevel < _pointer.Value.BracketLevel)
                                {
                                    _max = _pointer;
                                }
                                else if (_max.Value.BracketLevel == _pointer.Value.BracketLevel)
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
                                try
                                {
                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Add(a, b))); // Adds new node with result
                                }
                                catch (Exception exception)
                                {
                                    WriteHelp("outOfDouble");
                                    end = true;
                                    Clear_Click(sender, e);
                                }
                                break;
                            case "minus":
                                try
                                {
                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Subtract(a, b))); // Adds new node with result
                                }
                                catch (Exception exception)
                                {
                                    WriteHelp("outOfDouble");
                                    end = true;
                                    Clear_Click(sender, e);
                                }
                                break;
                            case "divide":
                                try
                                {
                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Divide(a, b))); // Adds new node with result
                                }
                                catch (Exception exception)
                                {
                                    if (b == 0)
                                    {
                                        warnings.Content = "Nastalo dělení nulou.\na/b -> a = " +
                                                           a.ToString(CultureInfo.InvariantCulture) + ", b = " +
                                                           b.ToString(CultureInfo.InvariantCulture);
                                    }
                                    else
                                    {
                                        WriteHelp("outOfDouble");
                                    }
                                    
                                    end = true;
                                    Clear_Click(sender, e);
                                }
                                break;
                            case "multiply":
                                try
                                {
                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Multiply(a, b))); // Adds new node with result
                                    
                                }
                                catch (Exception exception)
                                {
                                    WriteHelp("outOfDouble");
                                    end = true;
                                    Clear_Click(sender, e);
                                }
                                break;
                            case "power":
                                try
                                {

                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Power(a, (int) b))); // Adds new node with result
                                }
                                catch (Exception exception)
                                {
                                    WriteHelp("outOfDouble");
                                    end = true;
                                    Clear_Click(sender, e);
                                }

                                break;
                            case "root":
                                try
                                {
                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Root(b, (int) a))); // Adds new node with result
                                }
                                catch (Exception exception)
                                {
                                    if (a == 0)
                                        warnings.Content = "Nelze udělat nultou odmocninu z čísla";
                                    else if (a % 2 == 0 && b < 0)
                                        warnings.Content = "Nelze udělat sudou odmocninu ze zapornégo čísla";
                                    else
                                    {
                                        WriteHelp("outOfDouble");
                                        end = true;
                                        Clear_Click(sender, e);
                                        break;
                                    }
                                    
                                    warnings.Content += "\na^(1/n) -> a = " +
                                                        a.ToString(CultureInfo.InvariantCulture) + ", n = " +
                                                        b.ToString(CultureInfo.InvariantCulture);
                                    end = true;
                                    Clear_Click(sender, e);
                                }

                                break;
                            case "factorial":
                                if (Calculator.Factorial((int) a) == -1)
                                {
                                    warnings.Content = "Nelze udělat faktoriál ze záporného čísla.\na! -> a = " +
                                                       ((int) a).ToString(CultureInfo.InvariantCulture);
                                    end = true;
                                    Clear_Click(sender, e);
                                    break;
                                }

                                try
                                {
                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Factorial((int)a))); // Adds new node with result
                                }
                                catch (Exception exception)
                                {
                                    WriteHelp("outOfDouble");
                                    end = true;
                                    Clear_Click(sender, e);
                                }

                                break;
                            case "mod":
                                try
                                {
                                    DataList.AddBefore(_max.Previous,
                                        new Data(Calculator.Mod(a, b))); // Adds new node with result

                                }
                                catch (Exception exception)
                                {
                                    if (b != 0)
                                    {
                                        
                                            WriteHelp("outOfDouble");
                                            end = true;
                                            Clear_Click(sender, e);
                                            break;
                                    }

                                    warnings.Content = "Nastalo dělení nulou.\na%b -> a = " +
                                                       a.ToString(CultureInfo.InvariantCulture) + ", b = " +
                                                       b.ToString(CultureInfo.InvariantCulture);
                                    end = true;
                                    Clear_Click(sender, e);
                                }

                                break;
                            case "abs":
                                DataList.AddBefore(_max, new Data(Calculator.Abs(b))); // Adds new node with result
                                break;
                        }
                        
                        

                        if (end) break;
                        _head = DataList.First; // New head

                        if (_max.Value.Operation == "abs")
                        {
                            display.Text = _max.Previous.Value.Number.ToString(CultureInfo.InvariantCulture); // New text on display
                        }
                        else
                        {
                            display.Text = _max.Previous.Previous.Value.Number.ToString(CultureInfo.InvariantCulture); // New text on display
                        }

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
            else
            {
                WriteHelp("equal");
                return;
            }
            if (end) return;

            // Tidying after operation
            _count = display.Text.Length; // How many characters are displayed
            ResetCounter(ref _counter, ref _number);
            string text = display.Text;
            display.Text = "";
            if (_count > _displayMaxNumber) // Doesn't fit in display
            {
                for (int i = 0; i < _displayMaxNumber-1; i++) // Trims text
                {
                    display.Text += text[i].ToString();
                    _number[i] = text[i].ToString();
                }

                int value = text[_displayMaxNumber-1] - '0';
                if (text[_displayMaxNumber] >= '5') value++; // Rounding up

                display.Text += value.ToString();
                _number[_displayMaxNumber-1] = value.ToString();
                
                _count = _displayMaxNumber;
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
            if (_bracketLevel != 30) 
            {
                _bracketLevel = 30;
                WriteHelp("pair");
            }
        } // Button_calculate_Click()

        /// <summary>
        /// Catches key presses and links them to button functions
        /// </summary>
        /// <param name="sender">Reference to object</param>
        /// <param name="e">Data for the KeyUp and KeyDown routed events</param>
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
            if (e.Key == Key.Enter) // enter, serves as =
            {
                Button_calculate_Click(sender, e);
            }
            if (e.Key == Key.Back)
            {
                Clear_Click(sender, e);
            }
            if (e.Key == Key.Delete)
            {
                Clear_Click(sender, e);
            }
            if (e.Key == Key.A) // Temporary
            {
                Button_abs_Click(sender, e);
            }
        } // Key_press()

    } // class Calc
} //namespace Turbocalc
