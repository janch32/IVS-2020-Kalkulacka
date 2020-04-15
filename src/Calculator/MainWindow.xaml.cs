using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MathLib.Expression;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Match terms that shouldn't have space between them.
        /// </summary>
        private readonly Regex FormatterNoSpace = new Regex(@"([\d,\.\(\)!\^√]{2}|(?<![^\+\-×÷d]\s)-(\(|\d|e|π))$");
        
        /// <summary>
        /// Match number, Euler's number or Ludoplh's number.
        /// </summary>
        private readonly Regex MatchNumber = new Regex(@"^(\d|e|π)$");
        
        /// <summary>
        /// Match mathematical signs as multiply, divide, etc..
        /// </summary>
        private readonly Regex MatchSign = new Regex(@"^(,|\+|\-|×|÷|!|\^|√|\(|\))$");

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mouse drags move.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">MouseButtonEventArgs.</param>
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        /// <summary>
        /// Handle button input.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">KeyEventArgs.</param>
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    AppendExpression("0");
                    break;
                case Key.NumPad1:
                    AppendExpression("1");
                    break;
                case Key.NumPad2:
                    AppendExpression("2");
                    break;
                case Key.NumPad3:
                    AppendExpression("3");
                    break;
                case Key.NumPad4:
                    AppendExpression("4");
                    break;
                case Key.NumPad5:
                    AppendExpression("5");
                    break;
                case Key.NumPad6:
                    AppendExpression("6");
                    break;
                case Key.NumPad7:
                    AppendExpression("7");
                    break;
                case Key.NumPad8:
                    AppendExpression("8");
                    break;
                case Key.NumPad9:
                    AppendExpression("9");
                    break;
                case Key.Decimal:
                case Key.OemPeriod:
                case Key.OemComma:
                    AppendExpression(",");
                    break;
                case Key.Add:
                    PlusButtonClick(null, null);
                    break;
                case Key.Subtract:
                    MinusButtonClick(null, null);
                    break;
                case Key.Multiply:
                    MultiplyButtonClick(null, null);
                    break;
                case Key.Divide:
                    DivideButtonClick(null, null);
                    break;
                case Key.Back:
                    RemoveButtonClick(null, null);
                    break;
                case Key.Return:
                case Key.OemPlus:
                    EqualButtonClick(null, null);
                    break;
                case Key.Escape:
                case Key.Delete:
                    DeleteButtonClick(null, null);
                    break;
                case Key.D9:
                    LeftBracketButtonClick(null, null);
                    break;
                case Key.D0:
                    RightBracketButtonClick(null, null);
                    break;
                case Key.F1:
                   ShowHint(null, null);
                    break;
            }
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">ExecutedRoutedEventArgs.</param>
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Minimizes window.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void WindowMinimalize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Shows Help.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void ShowHint(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nevis? blby no.");
            // TODO: doplnit funkcnost
        }

        /// <summary>
        /// Checks if string is a number.
        /// </summary>
        /// <param name="s">Checked string</param>
        private bool IsNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return s.Any();
        }

        /// <summary>
        /// Checks if answer Text is Number and based on input term, uses answer for Expression. Clears answer.
        /// </summary>
        /// <param name="term">Any mathematical terminal</param>
        private void CheckAnswer(string term)
        {
            if (IsNumeric(Answer.Text) && MatchSign.IsMatch(term))
            {
                Expression.Text = Answer.Text;
                Answer.Text = "";
            }
            if (IsNumeric(Answer.Text) && MatchNumber.IsMatch(term))
            {
                Expression.Text = "";
                Answer.Text = "";
            }
        }
        
        /// <summary>
        /// Appends term to the end of expression.
        /// </summary>
        /// <param name="term">Any mathematical terminal</param>
        private void AppendExpression(string term)
        {
            CheckAnswer(term);

            if (Expression.Text.Length > 0 && !FormatterNoSpace.IsMatch(Expression.Text + term))
            {
                Expression.Text += " ";
            }

            Expression.Text += term;
        }

        /// <summary>
        /// Adds a number of buttons to Expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression(((Button)sender).Content.ToString());
        }

        /// <summary>
        /// Deletes expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text = "";
            Answer.Text = "";
            Grid.SetRowSpan(Expression, 2);
        }

        /// <summary>
        /// Deletes last char from expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (Expression.Text.EndsWith("mod"))
            {
                Expression.Text = Expression.Text.Remove(Expression.Text.Length - 3, 3);
            }
            else if (Expression.Text.Length > 0)
            {
                Expression.Text = Expression.Text.Remove(Expression.Text.Length - 1);
            }

            Expression.Text = Expression.Text.TrimEnd();
        }

        /// <summary>
        /// Adds pi to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PiButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("π");
        }

        /// <summary>
        /// Adds euler number to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void EulerButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("e");
        }

        /// <summary>
        /// Calls math library with expression and prints result.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void EqualButtonClick(object sender, RoutedEventArgs e)
        {
            Grid.SetRowSpan(Expression, 1);

            try
            {
                var parser = new Parser(Expression.Text);
                decimal result = parser.Evaluate();
                Answer.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                Answer.Text = "Divide by zero";
            }
            catch (ArithmeticException)
            {
                Answer.Text = "Arithmetic error";
            }
            catch (MathLib.Exceptions.ParseException)
            {
                Answer.Text = "Syntax Error";
            }            
            catch (Exception ex)
            {
                MessageBox.Show("Chyba aplikace: " + ex.Message);
            }
        }


        /// <summary>
        /// Adds plus to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("+");
        }

        /// <summary>
        /// Adds minus to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("-");
        }

        /// <summary>
        /// Adds multiply to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void MultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("×");
        }

        /// <summary>
        /// Adds divide to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("÷");
        }

        /// <summary>
        /// Adds left bracket to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void LeftBracketButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("(");
        }

        /// <summary>
        /// Adds right bracket to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RightBracketButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression(")");
        }

        /// <summary>
        /// Adds exclamation mark to the expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void FactorialButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("!");
        }

        /// <summary>
        /// Adds % to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void ModuloButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("mod");
        }

        /// <summary>
        /// Adds √ to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RootButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("√");
        }

        /// <summary>
        /// Adds ^ to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PowerButtonClick(object sender, RoutedEventArgs e)
        {
            AppendExpression("^");
        }
    }
}
