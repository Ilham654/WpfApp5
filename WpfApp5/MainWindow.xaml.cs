using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _result;

        public string Result
        {
            get { return _result; }
            set 
            {
                if (_result != value) 
                {
                    _result = value;
                    OnPropertyChanged("Result");
                }
            }
        }

        private double _number1;
        private double _number2;
        private string _operation;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string number = (sender as Button).Content.ToString();
            if (_operation == null)
            {
                Result = (Result == "0") ? number : Result + number;
            }
            else
            {
                Result = (Result == _number1.ToString()) ? number : Result + number;
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Result.Contains("."))
            {
                Result += ".";
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            _number1 = Convert.ToDouble(Result);
            _operation = (sender as Button).Content.ToString();
            Result = "0";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result = "0";
            _number1 = 0;
            _number2 = 0;
            _operation = null;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            _number2 = Convert.ToDouble(Result);
            switch (_operation)
            {
                case "+":
                    Result = (_number1 + _number2).ToString();
                    break;
                case "-":
                    Result = (_number1 - _number2).ToString();
                    break;
                case "*":
                    Result = (_number1 * _number2).ToString();
                    break;
                case "/":
                    if (_number2 == 0)
                    {
                        Result = "Error";
                    }
                    else
                    {
                        Result = (_number1 / _number2).ToString();
                    }
                    break;
            }
            _operation = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
