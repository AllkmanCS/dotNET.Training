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
        public T? this[int i, int j]
        {
            get
            {
                if (i < 0 && j < 0)
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
        public DiagonalMatrix(params T[] matrixElements)
        {
            if (matrixElements.Length < 0)
            {
                throw new ArgumentException();
            }
                _matrixElements = matrixElements;
        }
    }
}
