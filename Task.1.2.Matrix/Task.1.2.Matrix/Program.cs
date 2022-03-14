using Task._1._2.Matrix.Entities;
//TODO provide size so sqMatrix is 5 then its (5x5) and add element with indexer
//diagMatrix size 5 means the same 5x5
//default values where the matrix value is not set
var squareMatrix = new SquareMatrix<string>(2);
var squareMatrixInt = new SquareMatrix<int>(2);
squareMatrix[0,0] = "a";
squareMatrix[0,1] = "b";
squareMatrix[0,8] = "F";
squareMatrix[1,0] = "c";
squareMatrix[1,1] = "d";

squareMatrixInt[0, 0] = 1;
squareMatrixInt[0, 1] = 2;
squareMatrixInt[1, 0] = 3;
squareMatrixInt[1, 5] = 3; //cannot set
squareMatrixInt[1, 1] = 4;
Console.WriteLine(squareMatrix);
Console.WriteLine(squareMatrixInt);

var diagonalMatrix = new DiagonalMatrix<string>("a", "b", "c");
var diagonalMatrixInt = new DiagonalMatrix<int>(1, 2, 3);

diagonalMatrix[0,0] = "A";

diagonalMatrixInt[0, 0] = 8;


Console.WriteLine(diagonalMatrix);
Console.WriteLine(diagonalMatrixInt);