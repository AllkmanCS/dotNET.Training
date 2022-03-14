using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task._1._2.Matrix.Entities
{
    internal class DiagonalMatrix<T>
    {
        private T?[] _matrixElements;
        private int _size;
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;
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
                        OnElementChanged(new ElementChangedEventArgs<T>(i, oldValue, value));
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
        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }
    }
}
