using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
                    Expression.Text += "0";
                    break;
                case Key.NumPad1:
                    Expression.Text += "1";
                    break;
                case Key.NumPad2:
                    Expression.Text += "2";
                    break;
                case Key.NumPad3:
                    Expression.Text += "3";
                    break;
                case Key.NumPad4:
                    Expression.Text += "4";
                    break;
                case Key.NumPad5:
                    Expression.Text += "5";
                    break;
                case Key.NumPad6:
                    Expression.Text += "6";
                    break;
                case Key.NumPad7:
                    Expression.Text += "7";
                    break;
                case Key.NumPad8:
                    Expression.Text += "8";
                    break;
                case Key.NumPad9:
                    Expression.Text += "9";
                    break;
                case Key.Decimal:
                case Key.OemPeriod:
                case Key.OemComma:
                    Expression.Text += ",";
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
        }

        /// <summary>
        /// Adds a number of buttons to Expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += ((Button)sender).Content.ToString();
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
            if (Expression.Text.Length > 1)
            {
                Expression.Text = Expression.Text.Remove(Expression.Text.Length - 1);
            }
            else
            {
                Expression.Text = "";
            }
        }

        /// <summary>
        /// Adds pi to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PiButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "π";
        }

        /// <summary>
        /// Adds euler number to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void EulerButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "e";
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
                var parser = new MathLib.Expression.Parser(Expression.Text);
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
            Expression.Text += "+";
        }

        /// <summary>
        /// Adds minus to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "-";
        }

        /// <summary>
        /// Adds multiply to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void MultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "×";
        }

        /// <summary>
        /// Adds divide to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "÷";
        }

        /// <summary>
        /// Adds left bracket to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void LeftBracketButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "(";
        }

        /// <summary>
        /// Adds right bracket to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RightBracketButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += ")";
        }

        /// <summary>
        /// Adds exclamation mark to the expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void FactorialButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "!";
        }

        /// <summary>
        /// Adds % to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void ModuloButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "mod";
        }

        /// <summary>
        /// Adds √ to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RootButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "√";
        }

        /// <summary>
        /// Adds ^ to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PowerButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "^";
        }
    }
}
