using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task._1._2.Matrix.Entities
{
    /// <summary>
    /// A generic class to create data structure in Diagonal matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DiagonalMatrix<T>
    {
        /// <value>
        /// The <c>_size</c> field represents the size of the generic matrix
        /// </value>
        private int _size;
        /// <value>
        /// The <c>_matrixElements</c> field stores an array of generic types
        /// </value>
        private T?[] _matrixElements;
        /// <value>
        /// The <c>ElementChanged</c> event delegate for when an element in the matrix is changed.
        /// </value>
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;
        /// <summary>
        /// An indexer of the matrix class that provides the access to specified element in the matrix
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T? this[int i, int j]
        {
            get
            {
                if (i < 0 && j < 0 || i >= _size && j >= _size)
                {
                    throw new IndexOutOfRangeException();
                }
                if (i != j)
                {
                    return default(T);
                }
                else if (i == j)
                {
                    return _matrixElements[i];
                }
                else return default(T);
            }
            set
            {
                if (i < 0 && j < 0 || i >= _size && j >= _size)
                {
                    throw new IndexOutOfRangeException();
                }
                if (i >= 0 && j >= 0 || i <= _size && j <= _size || i == j)
                {
                    T? oldValue = _matrixElements[i];
                    _matrixElements[i] = value;
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
                _size = matrixElements.Length;
                _matrixElements = new T[_size];
                Array.Copy(matrixElements, _matrixElements, _size);
            }
        }
        /// <summary>
        /// A methos to test matrix class on Program.cs
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_size == 0)
            {
                return string.Empty;
            }
            for (int row = 0; row < _size; row++)
            {
                sb.AppendLine();
                for (int column = 0; column < _size; column++)
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
