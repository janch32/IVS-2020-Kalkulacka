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
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                Expression.Text += (int)e.Key - (int)Key.NumPad0; ;
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
            var parser = new MathLib.Expression.Parser(Expression.Text);
            decimal v = parser.Evaluate();
            Answer.Text = v.ToString();
            //Answer_TextBox_Row.Height = new GridLength(0.6, GridUnitType.Star);
            Grid.SetRowSpan(Expression, 1);
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
            Expression.Text += "*";
        }

        /// <summary>
        /// Adds divide to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += "/";
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
            Expression.Text += "%";
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
