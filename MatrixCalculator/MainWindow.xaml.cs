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
using MatrixCalculator.MatrixOperations;

namespace MatrixCalculator
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

        private double[,] GetMatrixInputAsDoubleArray()
        {
            // process input
            string inputText = this.MatrixInputTextbox.Text;
            string[] lines = inputText.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var finalDoubleList = new List<List<double>>();
            foreach (var line in lines)
            {
                string[] numbers = line.Split(' ');
                var doubleList = new List<double>();
                foreach (var number in numbers)
                {
                    doubleList.Add(Convert.ToDouble(number));
                }
                finalDoubleList.Add(doubleList);
            }

            double[,] finalDoubleArray = new double[lines.Count(), lines.Count()];
            for (int i = 0; i < lines.Count(); i++)
            {
                for (int j = 0; j < lines.Count(); j++)
                {
                    finalDoubleArray[i, j] = finalDoubleList[i][j];
                }

            }
            return finalDoubleArray;
        }

        private void MatrixInverseButton_Click(object sender, RoutedEventArgs e)
        {

            this.MatrixOutputTextbox.Text = MatrixOperations.MatrixOperations.CalculateInverse(GetMatrixInputAsDoubleArray()).ToString();
        }

        private void MatrixDeterminantButton_Click(object sender, RoutedEventArgs e)
        {

            this.MatrixOutputTextbox.Text = MatrixOperations.MatrixOperations.CalculateDeterminant(GetMatrixInputAsDoubleArray()).ToString();
        }

        private void MatrixCholeskyButton_Click(object sender, RoutedEventArgs e)
        {
            this.MatrixOutputTextbox.Text = MatrixOperations.MatrixOperations.CalculateCholesky(GetMatrixInputAsDoubleArray()).ToString();
        }
    }
}
