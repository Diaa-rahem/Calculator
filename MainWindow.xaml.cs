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
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string resultString;
        double lastNumber, resutl;
        
        bool vide;
        bool point;


        bool firstBool = true;
        double firstNum;

        public MainWindow()
        {
            InitializeComponent();
            cButton.Click += CButton_Click;
            negativeButton.Click += NegativeButton_Click;
            ButtonPerc.Click += ButtonPerc_Click;
            ButtonEqual.Click += ButtonEqual_Click;
            ButtonPoint.Click += ButtonPoint_Click;          
        }

        private void ButtonPoint_Click(object sender, RoutedEventArgs e)
        {   if (point)
            {
                //do ntithing 
            }
            else
            {
                labelResult.Content = $"{labelResult.Content}.";
                resultString  = $"{resultString}.";
                point = true;
            }
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {  if (resultString.ToString().Contains("/0"))
            { MessageBox.Show("U cant divide by zero ");
                resultString = "0";
                labelResult.Content = "0";

            }
            else
            {
                labelResult.Content = new DataTable().Compute(resultString, null).ToString();
                resultString = labelResult.Content.ToString();
            }
            
        }

        private void ButtonPerc_Click(object sender, RoutedEventArgs e)
        {   
            
                lastNumber = lastNumber / 100 ;
                resultString = resultString +"/100" ;
                labelResult.Content = $"{labelResult.Content}/100" ;

            
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResult.Content.ToString(), out lastNumber))
            {

                lastNumber = lastNumber * -1;
                resultString = resultString + lastNumber.ToString();
                labelResult.Content = lastNumber.ToString();
            }
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            labelResult.Content = "0";
            lastNumber = 0;
            
            resultString = "0";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {

            if (vide)
            {
                if (sender == multiplicationButton)
                {
                    labelResult.Content = labelResult.Content + "×";
                    resultString = resultString +"*";
                }
                if (sender == ButtonDiv)
                {
                    labelResult.Content = labelResult.Content + "÷";
                    resultString = resultString + "/";
                }
                if (sender == soustractionButton)
                {
                    labelResult.Content = labelResult.Content + "-";
                    resultString = resultString + "-";
                }
                if (sender == ButtonPlus)
                {
                    labelResult.Content = labelResult.Content + "+";
                    resultString = resultString + "+";
                }
                vide = false;
                
            }
            else
            {
                //Do nothing

            }
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());
            point = false;
            if (labelResult.Content.ToString() == "0")
            {
                labelResult.Content = $"{selectedValue}";
                resultString = $"{selectedValue}";

            }
            else
            {
                labelResult.Content = $"{labelResult.Content}{selectedValue}";
                resultString = $"{resultString}{selectedValue}";

            }
            vide = true;
        }
        
    }
    
    
}
