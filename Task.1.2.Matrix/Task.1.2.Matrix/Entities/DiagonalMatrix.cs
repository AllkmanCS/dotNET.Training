using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Two.Matrix.Entities
{
    /// <summary>
    /// A generic class to create data structure in Diagonal matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Diagonal matrix indexer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public override T? this[int i, int j]
        {
            get
            {
                if (i < 0 && j < 0 || i >= Size && j >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                if (i != j)
                {
                    return default(T);
                }
                else if (i == j)
                {
                    return MatrixElements[i];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                if (i >= 0 && j >= 0 || i <= Size && j <= Size || i == j)
                {
                    T? oldValue = MatrixElements[i];
                    MatrixElements[i] = value;
                    if (!EqualityComparer<T>.Default.Equals(oldValue, value))
                    {
                        OnElementChanged(new ElementChangedEventArgs<T>(i, oldValue));
                    }
                }
            }
        }
        public DiagonalMatrix(params T?[] matrixElements)
        {
            if (matrixElements.Length < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Size = matrixElements.Length;
                MatrixElements = matrixElements;
            }
        }
    }
}
