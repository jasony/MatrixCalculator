using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MatrixCalculator.MatrixOperations;
using System.Windows.Input;

namespace MatrixCalculator.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        protected void RaiseEvent(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _inputMatrixText;
        private string _outputMatrixText;

        public String InputMatrixText
        {
            get
            {
                return _inputMatrixText;
            }
            set 
            {
                _inputMatrixText = value;
                RaiseEvent("InputMatrixText");
            }
        }

        public String OutputMatrixText
        {
            get
            {
                return _outputMatrixText;
            }
            set
            {
                _outputMatrixText = value;
                RaiseEvent("OutputMatrixText");
            }
        }

        #region Commands
        public ICommand MatrixInverseCommand
        {
            get
            {
                return new CommandHandler(() => this.OutputMatrixText = MatrixOperations.MatrixOperations.CalculateInverse(GetMatrixInputAsDoubleArray()).ToString(), true);
            }
        }

        public ICommand MatrixDeterminantCommand
        {
            get
            {
                return new CommandHandler(() => this.OutputMatrixText = MatrixOperations.MatrixOperations.CalculateDeterminant(GetMatrixInputAsDoubleArray()).ToString(), true);
            }
        }

        public ICommand MatrixCholeskyCommand
        {
            get
            {
                return new CommandHandler(() => this.OutputMatrixText = MatrixOperations.MatrixOperations.CalculateCholesky(GetMatrixInputAsDoubleArray()).ToString(), true);
            }
        }

        public ICommand MatrixIdentityCommand
        {
            get
            {
                return new CommandHandler(() => this.OutputMatrixText = "Identity", true);
            }
        }
        #endregion

        private double[,] GetMatrixInputAsDoubleArray()
        {
            // process input
            string inputText = InputMatrixText;
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
    }
}
