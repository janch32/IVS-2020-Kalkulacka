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
using MathLib;
using MathLib.Expression;
using MathLib.Exceptions;


namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMathLibrary Library { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Library = MathLibraryFactory.Build();
        }
        /// <summary>
        ///     MOuse drag move.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">MouseButtonEventArgs.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        /// <summary>
        ///     Closes window.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">ExecutedRoutedEventArgs.</param>
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        ///     Minimalizes window.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void Window_Minimalize(object sender, RoutedEventArgs e)
        {
            MyWindow.WindowState = WindowState.Minimized;
        }
        /// <summary>
		///     Adds number of button to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void N_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += ((Button)sender).Content.ToString();
        }
        /// <summary>
		///     Deletes expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text = "";
        }
        /// <summary>
		///     deletes last char from expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Expresion_TextBox.Text.Length > 1)
            {
                Expresion_TextBox.Text = Expresion_TextBox.Text.Remove(Expresion_TextBox.Text.Length - 1);
            }
            else
            {
                Expresion_TextBox.Text = "";
            }
        }
        /// <summary>
		///     Adds pi to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Pi_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "π";
        }
        /// <summary>
		///     Adds euler number to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Euler_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "e";
        }
        /// <summary>
		///     Calls math library with expresion and prints result.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Equal_Button_Click(object sender, RoutedEventArgs e)
        {
            var parser = new MathLib.Expression.Parser(Expresion_TextBox.Text);
            decimal v = parser.Evaluate();
            Answer_TextBox.Text = v.ToString();
        }
        /// <summary>
		///     Adds plus to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "+";
        }
        /// <summary>
		///     Adds minus to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "-";
        }
        /// <summary>
		///     Adds multiply to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "*";
        }
        /// <summary>
		///     Adds divide to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Divide_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "/";
        }
        /// <summary>
		///     Adds left bracket to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Left_Bracket_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "(";
        }
        /// <summary>
		///     Adds right bracket to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Right_Bracket_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += ")";
        }
        /// <summary>
		///     Adds exclamation mark to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Factorial_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "!";
        }
        /// <summary>
		///     Adds % to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Modulo_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "%";
        }
        /// <summary>
		///     Adds √ to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Root_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "√";
        }
        /// <summary>
		///     Adds ^ to expresion.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Power_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "^";
        }
    }
}
