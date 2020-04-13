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
        /// Adds a number of buttons to expresion.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += ((Button)sender).Content.ToString();
        }

        /// <summary>
        /// Deletes expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text = "";
        }

        /// <summary>
        /// Deletes last char from expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (Expresion.Text.Length > 1)
            {
                Expresion.Text = Expresion.Text.Remove(Expresion.Text.Length - 1);
            }
            else
            {
                Expresion.Text = "";
            }
        }

        /// <summary>
        /// Adds pi to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PiButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "π";
        }

        /// <summary>
        /// Adds euler number to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void EulerButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "e";
        }

        /// <summary>
        /// Calls math library with expression and prints result.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void EqualButtonClick(object sender, RoutedEventArgs e)
        {
            var parser = new MathLib.Expression.Parser(Expresion.Text);
            decimal v = parser.Evaluate();
            Answer.Text = v.ToString();
            //Answer_TextBox_Row.Height = new GridLength(0.6, GridUnitType.Star);
            Grid.SetRowSpan(Expresion, 1);
        }

        /// <summary>
        /// Adds plus to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "+";
        }

        /// <summary>
        /// Adds minus to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "-";
        }

        /// <summary>
        /// Adds multiply to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void MultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "*";
        }

        /// <summary>
        /// Adds divide to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "/";
        }

        /// <summary>
        /// Adds left bracket to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void LeftBracketButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "(";
        }

        /// <summary>
        /// Adds right bracket to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RightBracketButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += ")";
        }

        /// <summary>
        /// Adds exclamation mark to the expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void FactorialButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "!";
        }

        /// <summary>
        /// Adds % to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void ModuloButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "%";
        }

        /// <summary>
        /// Adds √ to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void RootButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "√";
        }

        /// <summary>
        /// Adds ^ to expression.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void PowerButtonClick(object sender, RoutedEventArgs e)
        {
            Expresion.Text += "^";
        }
    }
}
