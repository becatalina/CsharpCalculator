using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Calculator.Exceptions;

namespace Calculator
{

    public partial class MainWindow : Window
    {
        public bool IsRo { get; set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            displayTextbox.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)); 
  
        }


        private void NumOpButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                ValidateInput(button.Content.ToString());
                displayTextbox.Text += button.Content.ToString();

                var input = displayTextbox.Text.ToString();
                Utils.AddComma(ref input, IsRo);

                displayTextbox.Text = input;
                errorBox.Text = "";
            }
            catch (InvalidOperatorExxception ex)
            {
                errorBox.Text = ex.Message;
                return;
            }
            catch (InvalidInputException ex)
            {
                errorBox.Text = ex.Message;
                return;
            }
            catch (NotANumberException ex)
            {
                errorBox.Text = ex.Message;
                return;
            }
            catch (InvalidParanthesisException ex) {
                errorBox.Text = ex.Message;
                return;
            }
            
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter)
            {
                try
                {
                    displayTextbox.Text = Utils.Solve(displayTextbox.Text).ToString(); 
                    return;
                }
                catch (DivideByZeroException ex)
                {
                    errorBox.Text = "Cannot divide by zero";
                }
                catch (Exception ex)
                {
                    errorBox.Text = "Error! Try again.";
                }
            }
            try
            {
                var userInput = (!displayTextbox.Text.ToString().Equals("")) ? e.ToString()
                : "";

                if (userInput.Equals(""))
                    return;

                ValidateInput(userInput);
            }
            catch (InvalidOperatorExxception)
            {
                displayTextbox.Text = displayTextbox.Text.Remove(displayTextbox.Text.Length - 1);
                return;
            }
            catch (InvalidInputException)
            {
                displayTextbox.Text = displayTextbox.Text.Remove(displayTextbox.Text.Length - 1);
                return;
            }
            catch (NotANumberException)
            {
                displayTextbox.Text = displayTextbox.Text.Remove(displayTextbox.Text.Length - 1);
                return;
            }
            catch (Exception)
            {
                throw;
            }
            
            

        }
        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String input = displayTextbox.Text.ToString();
                if (IsRo) { Utils.SwitchLang(ref input); }

                input = Utils.Solve(input.Replace(",", "")).ToString();
                Utils.AddComma(ref input, IsRo);
                displayTextbox.Text = input;

            }
            catch (DivideByZeroException ex) {

                displayTextbox.Text = "Cannot divide by zero";

            }
            catch (Exception ex)
            {
                displayTextbox.Text = "Error! Try again.";
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            displayTextbox.Text = "";
        }
        private void ValidateInput(string userInput) {

            var formerInput = (!displayTextbox.Text.ToString().Equals("")) ? displayTextbox.Text[displayTextbox.Text.Length - 1].ToString()
                : "";

            if (formerInput.Equals(""))
                return;

            Regex operators = new Regex(@"[+\/\-*]");
            Regex alpha = new Regex(@"^[a-zA-Z\s]*$");
            Regex numeric = new Regex("[0-9]");

            
            if (alpha.IsMatch(userInput)) {
                throw new InvalidInputException(userInput);
            }
            if (operators.IsMatch(formerInput) && !numeric.IsMatch(userInput)) {
                throw new NotANumberException(userInput);
            }
            if (operators.IsMatch(formerInput) && operators.IsMatch(userInput)) {
                throw new InvalidOperatorExxception(userInput);
            }



        }

        private void langButton_Click(object sender, RoutedEventArgs e)
        {

            String input = displayTextbox.Text.ToString();

            if (IsRo) {
                IsRo = false;
                langButton.Content = "EN";
                decPointButton.Content = ".";

                Utils.SwitchLang(ref input);
                displayTextbox.Text = input;
                return;
            }

            IsRo = true;
            langButton.Content = "RO";
            decPointButton.Content = ",";

            Utils.SwitchLang(ref input);
            displayTextbox.Text = input;

        }
    }
}
