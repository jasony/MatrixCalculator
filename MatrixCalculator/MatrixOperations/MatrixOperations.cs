using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MatrixCalculator.MatrixOperations
{
    public static class MatrixOperations
    {
        public static Matrix<double> CalculateInverse(double[,] inputDoubleArray)
        {
            var inputMatrix = DenseMatrix.OfArray(inputDoubleArray);
            return inputMatrix.Inverse();
        }

        public static double CalculateDeterminant(double[,] inputDoubleArray)
        {
            var inputMatrix = DenseMatrix.OfArray(inputDoubleArray);
            return inputMatrix.Determinant();
        }

        public static Matrix<double> CalculateCholesky(double[,] inputDoubleArray)
        {
            var inputMatrix = DenseMatrix.OfArray(inputDoubleArray);
            return inputMatrix.Cholesky().Factor;
        }
    }
}
