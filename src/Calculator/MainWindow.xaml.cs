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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Minimalize(object sender, RoutedEventArgs e)
        {
            MyWindow.WindowState = WindowState.Minimized;
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void N_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += ((Button)sender).Content.ToString();
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text = "";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Pi_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "π";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Euler_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "e";
        }
        /// <summary>
		///     Handle numeric button click.
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
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "+";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "-";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "*";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Divide_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "/";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Left_Bracket_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "(";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Right_Bracket_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += ")";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Factorial_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "!";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Modulo_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "%";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Root_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "√";
        }
        /// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void Power_Button_Click(object sender, RoutedEventArgs e)
        {
            Expresion_TextBox.Text += "^";
        }
    }
}
