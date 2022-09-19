using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement el in GroupButtons.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            string textButton = ((Button)e.OriginalSource).Content.ToString();
            
            try
            {
                
                switch (textButton)
                {
                    case "C":
                        text.Clear();
                        result.Clear();
                        break;

                    case "CE":
                        text.Clear();
                        result.Clear();
                        break;

                    case "√":
                        
                        result.Text = Math.Sqrt(double.Parse(text.Text)).ToString();
                        break;
                       

                    case "←":
                        result.Text = text.Text.Substring(text.Text.Length - 1);
                        break;

                    //case "±":
                    //    if (text.Text[0] == '-')
                    //    {
                    //        text.Text = text.Text.Remove(0, 1);
                    //    }
                    //    else
                    //    {
                    //        text.Text = text.Text.Prepend('-').ElementAt(0).ToString() + text.Text;
                    //    }


                    //    break;

                    case "=":
                        result.Text = new DataTable().Compute(text.Text, null).ToString();
                        break;

                    case "×":
                        text.Text += "*";
                        break;

                    case "/":
                        text.Text += "/";
                        break;

                    case "+":
                        text.Text += "+";
                        break;

                    case "-":
                        text.Text += "-";
                        break;

                    case "%":
                        text.Text += "%";
                        break;


                    default:
                        text.Text += textButton;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
