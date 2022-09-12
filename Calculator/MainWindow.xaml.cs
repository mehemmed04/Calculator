using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Operation { get; set; }
        bool IsOperationPerfomed = false;
        double resultValue = 0;
        public MainWindow(){
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (Result_Txtb.Text == "0" || IsOperationPerfomed)
                {
                    Result_Txtb.Text = "";
                }
                IsOperationPerfomed = false;
                if (btn.Content.ToString() == ",")
                {
                    if (!Result_Txtb.Text.Contains(","))
                    {
                        Result_Txtb.Text += btn.Content.ToString();
                    }
                    if (Result_Txtb.Text.Length == 1)
                    {
                        Result_Txtb.Text = Result_Txtb.Text.Insert(0, "0");
                    }
                }
                else Result_Txtb.Text += btn.Content.ToString();
            }
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            if (!IsOperationPerfomed)
            {
                if (sender is Button btn)
                {
                    if (resultValue != 0)
                    {
                        equals_btn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                        
                        Operation = btn.Content.ToString();
                        CurrentOperation.Text = resultValue + " " + Operation;
                        IsOperationPerfomed = true;
                    }
                    else
                    {
                        Operation = btn.Content.ToString() ;
                        resultValue = Double.Parse(Result_Txtb.Text);
                        CurrentOperation.Text = resultValue + " " + Operation;
                        IsOperationPerfomed = true;
                    }
                }
            }
        }

        private void equals_btn_Click(object sender, RoutedEventArgs e)
        {
            double number = Double.Parse(Result_Txtb.Text);
            switch (Operation)
            {
                case "+":
                    Result_Txtb.Text = (resultValue + number).ToString();
                    break;
                case "-":
                    Result_Txtb.Text = (resultValue - number).ToString();
                    break;
                case "/":
                    Result_Txtb.Text = (resultValue / number).ToString();
                    break;
                case "*":
                    Result_Txtb.Text = (resultValue * number).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(Result_Txtb.Text);
            Operation = "";
            CurrentOperation.Text = "";
        }

        private void C_Btn_Click(object sender, RoutedEventArgs e)
        {
            Result_Txtb.Text = "0";
            resultValue = 0;
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Result_Txtb.Text = "0";
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void close_app_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize_app_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }


}
