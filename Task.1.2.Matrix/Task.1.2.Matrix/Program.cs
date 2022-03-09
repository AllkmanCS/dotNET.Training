using Task._1._2.Matrix.Entities;
//TODO provide size so sqMatrix is 5 then its (5x5) and add element with indexer
//diagMatrix size 5 means the same 5x5
//default values where the matrix value is not set
int[] squareMatrixElements = { 2, 6, 8, 4, 9, 8 };
var squareMatrix = new SquareMatrix<int>(squareMatrixElements);
Console.WriteLine(squareMatrix);
