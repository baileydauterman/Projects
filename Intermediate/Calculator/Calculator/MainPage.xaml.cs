using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Perception.Spatial;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("1");
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("2");
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("3");
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("4");
        }

        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("5");
        }

        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("6");
        }

        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("7");
        }

        private void button_8_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("8");
        }

        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAdd("9");
        }

        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                TextBoxAdd("0");
            }
        }

        private void button_percent_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = (double.Parse(textBox.Text) / 100.0).ToString();
        }

        private void button_ce_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
            rpn.Clear();
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Join(string.Empty, textBox.Text.Take(textBox.Text.Length - 1));
        }

        private void button_decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!textBox.Text.Contains("."))
            {
                TextBoxAdd(".");
            }
        }

        private void button_div_Click(object sender, RoutedEventArgs e)
        {
            PushAndClear("/");
        }

        private void button_multi_Click(object sender, RoutedEventArgs e)
        {
            PushAndClear("*");
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            PushAndClear("+");
        }

        private void button_sub_Click(object sender, RoutedEventArgs e)
        {
            PushAndClear("-");
        }

        private void button_negate_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.StartsWith("-"))
            {
                textBox.Text = textBox.Text.Skip(2).ToString();
                return;
            }

            textBox.Text = $"-{textBox.Text}";
        }

        private void button_equal_Click(object sender, RoutedEventArgs e)
        {
            if (rpn.Any())
            {
                PushAndClear("=");
            }
        }

        private void TextBoxAdd(string str)
        {
            textBox.Text += str;
        }

        private void PushAndClear(string operand)
        {
            // Prevents adding multiple operands to the stack
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }

            if (rpn.Any())
            {
                var op = rpn.Pop();
                var num = decimal.Parse(rpn.Pop());
                decimal current = decimal.Parse(textBox.Text);

                switch (op)
                {
                    case "+":
                        textBox.Text = (num + current).ToString();
                        break;

                    case "-":
                        textBox.Text = (num - current).ToString();
                        break;

                    case "*":
                        textBox.Text = (num * current).ToString();
                        break;

                    case "/":
                        textBox.Text = (num / current).ToString();
                        break;
                }

                return;
            }

            rpn.Push(textBox.Text);
            rpn.Push(operand);

            textBox.Text = string.Empty;
        }

        private Stack<string> rpn = new Stack<string>();
    }
}
