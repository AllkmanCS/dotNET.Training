using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task._1._2.Matrix.Entities
{
    internal class SquareMatrix<T>
    {
        private T?[] _matrixElements;
        private int _size;
        public T? this[int i, int j]
        {
            get
            {
                if (i < 0 && j < 0 || i >= _size && j >= _size) // dont allow negative
                {
                    throw new IndexOutOfRangeException();
                }
                
                return _matrixElements[i];
            }
            set
            {
                _matrixElements[i] = value;
            }
        }
        public SquareMatrix(params T[] matrixElements)
        {
            if (matrixElements.Length < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                _size = matrixElements.Length;
                _matrixElements = new T[_size];
                Array.Copy(_matrixElements, 0, _matrixElements, 0, _size);
            }
            _matrixElements = matrixElements;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_matrixElements.Length == 0)
            {
                return string.Empty;
            }
            for (int i = 0; i < _matrixElements.Length; i++)
            {
                sb.AppendLine();
                for (int j = 0; j < _matrixElements.Length; j++)
                {
                    sb.Append(this[i, j]);
                }
            }
            return sb.ToString();
        }
    }
}
