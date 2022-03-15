using Task._1._2.Matrix.Entities;
#region SquareMatrix testing
ElementChangedEventArgs<string> eventArgs = new ElementChangedEventArgs<string>();
var stringSquareMatrix = new SquareMatrix<string>("a", "b");
stringSquareMatrix.ElementChanged += (s, e) =>
{
    Console.WriteLine($"Old value {e.OldValue} at index {e.Index}");
};

stringSquareMatrix[1, 0] = "F";
Console.WriteLine(stringSquareMatrix);

var intSquareMatrix = new SquareMatrix<int>(2, 1, 5, 3);
intSquareMatrix.ElementChanged += (s, e) =>
{
    Console.WriteLine($"Old value {e.OldValue} at index {e.Index}");
};
intSquareMatrix[0, 0] = 6;

Console.WriteLine(intSquareMatrix);
#endregion

#region DiagonalMatrix
var diagonalMatrix = new DiagonalMatrix<string>("a", "b", "c");
var diagonalMatrixInt = new DiagonalMatrix<int>(1, 2, 3);

diagonalMatrix[0,0] = "A";
diagonalMatrix.ElementChanged += (s, e) =>
{
    diagonalMatrix[e.Index, e.Index] = e.OldValue;
};
diagonalMatrixInt[0, 0] = 8;
diagonalMatrixInt.ElementChanged += (s, e) =>
{
    diagonalMatrixInt[e.Index, e.Index] = e.OldValue;
};
Console.WriteLine(diagonalMatrix);
Console.WriteLine(diagonalMatrixInt);
#endregion