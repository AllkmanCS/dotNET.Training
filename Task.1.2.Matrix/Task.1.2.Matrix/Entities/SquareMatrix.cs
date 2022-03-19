using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Two.Matrix.Entities
{
    /// <summary>
    /// A generic class to create data structure in Square matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SquareMatrix<T>
    {
        /// <value>
        /// The <c>_size</c> field represents the size of the generic matrix
        /// </value>
        public int Size;
        /// <value>
        /// The <c>_matrixElements</c> field stores an array of generic types
        /// </value>
        public T?[] MatrixElements;
        /// <value>
        /// The <c>ElementChanged</c> event delegate for when an element in the matrix is changed.
        /// </value>
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;
        /// <summary>
        /// An indexer of the matrix class that provides the access to specified element in the matrix.
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public virtual T? this[int i, int j]
        {
            get
            {
                if (i < 0 && j < 0 || i >= Size && j >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return MatrixElements[j];
                }
            }
            set
            {
                if (i > 0 && j > 0 || i <= Size && j <= Size)
                {
                    T? oldValue = MatrixElements[j];
                    MatrixElements[j] = value;
                    if (!EqualityComparer<T>.Default.Equals(oldValue, value))
                    {
                        OnElementChanged(new ElementChangedEventArgs<T>(j, oldValue));
                    }
                }
            }
        }
        public SquareMatrix(params T?[] matrixElements)
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
        /// <summary>
        /// A methos to test matrix class on Program.cs
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Size == 0)
                return string.Empty;

            for (int row = 0; row < Size; row++)
            {
                sb.AppendLine();
                for (int column = 0; column < Size; column++)
                {
                    sb.Append(this[row, column]);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// A method to raise an event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }
    }
}
