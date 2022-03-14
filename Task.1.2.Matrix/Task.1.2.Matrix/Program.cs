using Task._1._2.Matrix.Entities;
#region SquareMatrix testing
var squareMatrix = new SquareMatrix<string>("a", "b");
squareMatrix[0, 0] = "F";
squareMatrix.ElementChanged += (s, e) => 
{ var old = squareMatrix[e.Index, e.Index] = e.OldValue;
    Console.WriteLine(old);
};

var squareMatrixInt = new SquareMatrix<int>(2, 1, 5, 3);
squareMatrixInt[0, 0] = 6;

Console.WriteLine(squareMatrix);
Console.WriteLine(squareMatrixInt);
#endregion

#region DiagonalMatrix
var diagonalMatrix = new DiagonalMatrix<string>("a", "b", "c");
var diagonalMatrixInt = new DiagonalMatrix<int>(1, 2, 3);

diagonalMatrix[0,0] = "A";

diagonalMatrixInt[0, 0] = 8;


Console.WriteLine(diagonalMatrix);
Console.WriteLine(diagonalMatrixInt);
#endregion