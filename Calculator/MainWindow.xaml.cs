using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Calculator
{

    public partial class MainWindow : Window
    {
        private Utils cal;
        private Calc calculator = new Calc();
        public MainWindow()
        {
            cal = new Utils();
            
            InitializeComponent();
            displayTextbox.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)); 
         
            
        }


        private void NumOpButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            displayTextbox.Text += button.Content.ToString();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Calculate();
                }
                catch (DivideByZeroException ex)
                {
                    displayTextbox.Text = "Cannot divide by zero";
                }
                catch (Exception ex)
                {
                    displayTextbox.Text = "Error! Try again.";
                }
            }
            

        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (DivideByZeroException ex) {

                displayTextbox.Text = "Cannot divide by zero";

            }
            catch (Exception ex)
            {
                displayTextbox.Text = "Error! Try again.";
            }
        }

        private void Calculate()
        {
            //int opPos = 0;
            //double value1 = 0;
            //double value2 = 0;
            //double result = 0;
            //string op = "";

            //if (displayTextbox.Text.Contains("*"))
            //{
            //    opPos = displayTextbox.Text.IndexOf("*");
            //}
            //else if (displayTextbox.Text.Contains("/"))
            //{
            //    opPos = displayTextbox.Text.IndexOf("/");
            //}
            //else if (displayTextbox.Text.Contains("+"))
            //{
            //    opPos = displayTextbox.Text.IndexOf("+");
            //}
            //else if (displayTextbox.Text.Contains("-"))
            //{
            //    opPos = displayTextbox.Text.IndexOf("-");
            //}


            //value1 = Double.Parse(displayTextbox.Text.Substring(0, opPos));
            //op = displayTextbox.Text.Substring(opPos, 1);
            //value2 = Double.Parse(displayTextbox.Text.Substring(opPos + 1, displayTextbox.Text.Length - opPos - 1));

            //if (op == "*")
            //{
            //    result = cal.multiply(value1, value2);
            //    displayTextbox.Text = result.ToString();
            //}
            //else if (op == "/")
            //{
            //    if (value2 == 0)
            //    {
            //        displayTextbox.Text = "Cannot divide by zero!";
            //    }
            //    else
            //    {
            //        result = cal.divide(value1, value2);
            //        displayTextbox.Text = result.ToString();
            //    }
            //}
            //else if (op == "+")
            //{
            //    result = cal.add(value1, value2);
            //    displayTextbox.Text = result.ToString();
            //}
            //else if (op == "-")
            //{
            //    result = cal.subtract(value1, value2);
            //    displayTextbox.Text = result.ToString();
            //}

            displayTextbox.Text = calculator.Solve(displayTextbox.Text).ToString(); 

            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            displayTextbox.Text = "";
        }

        
    }
}
