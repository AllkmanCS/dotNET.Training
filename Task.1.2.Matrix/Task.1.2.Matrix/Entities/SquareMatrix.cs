using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task._1._2.Matrix.Entities
{
    internal class SquareMatrix<T>
    {
        private struct Key
        {
            public int RowIndex { get; set; }
            public int ColumnIndex { get; set; }
            public Key(int rowIndex, int columnIndex)
            {
                RowIndex = rowIndex;
                ColumnIndex = columnIndex;
            }
        }
        private int _size;
        private Dictionary<Key, T> _cells = new Dictionary<Key, T>();
        private T?[] _matrixElements;
        public T? this[int i, int j]
        {
            get
            {
                var key = new Key(i, j);
                T? value;
                return _cells.TryGetValue(key, out value) ? value : default;
            }
            set
            {
                var key = new Key(i, j);
                _cells[key] = value;
            }
        }
        public SquareMatrix(int size)
        {
            _size = size >= 0 ? size : throw new ArgumentException();
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
    }
}
