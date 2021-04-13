using System;
using System.Collections.Generic;
using System.Linq;
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
        private string[] str = new string[600];
        private int counter = 0;
        private int count = 0;

        public struct Data
        {
            public Data(double number, char operation, int weigth)
            {
                Number = number;
                Operation = operation;
                Weigth = weigth;
            }

            public double Number { get; }
            public char Operation { get; }
            public int Weigth { get; }
        }

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
                for (int i = 2; i < 12; i++)
                {
                    display.Text = display.Text + text[i].ToString();
                }
            }
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text+"0";
            
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "1";
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "2";
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "3";
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "4";
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "5";
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "6";
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "7";
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "8";
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "9";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            display.Text = "";
        }

        private void Button_point_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + ".";
        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "+";
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "-";
        }

        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "÷";
        }

        private void Button_multiply_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "x";
        }

        private void Button_factorial_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "!";
        }

        private void Button_root_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "√";
        }

        private void Button_power_Click(object sender, RoutedEventArgs e)
        {
            fitInBox();
            display.Text = display.Text + "xⁿ";
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

        }
    }
}
