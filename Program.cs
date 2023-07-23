using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace cmtecnologia;
class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = CreateMatrix();
        InvertTheDiagonalOfTheMatrix(matrix);
        FindsubMatrix(matrix);
    }   

    public static int[,] CreateMatrix(){

        Console.WriteLine("Enter the array size: ");
        string? size = Console.ReadLine();
        Console.WriteLine();

        if(size != null){

            int sizeMatrix =  Int32.Parse(size);

            if(sizeMatrix != 0 ){

                int[,] matrix = new int[sizeMatrix, sizeMatrix];
                var rand = new Random();
                for( int line = 0; line < sizeMatrix; line++){
                    for(int column = 0; column < sizeMatrix; column++){
                        matrix[line,column] = rand.Next(0,9);
                        Console.Write("{0} ", matrix[line, column]);
                    } 

                    Console.WriteLine();
                }
                return matrix;
            }
            else{
                Console.WriteLine("There is no matrix with size 0");
                return null!;
            }
        }
        else{
            Console.WriteLine("Null value is not accepted.");
            return null!;

        } 
    }
    public static void InvertTheDiagonalOfTheMatrix(int[,] matrix){
        int arraysize =  matrix.GetLength(0);
        int[,] diagonals = GetDiagonals(matrix, arraysize);

        for(int line = 0; line < arraysize; line++){
            for(int column = 0; column < arraysize; column++){
                if(line == column){
                    matrix[line,column] = diagonals[1,column];
                }
                if((line + column) == arraysize - 1){
                    matrix[line, column] = diagonals[0,column];
                }
                Console.Write("{0} ", matrix[line, column]);
            }
            Console.WriteLine();
        }
    }

    public static int [,] GetDiagonals(int[,] matrix, int arraysize){
        int [,] diagonals = new int [2,arraysize];

        for(int line = 0; line < arraysize; line++){
            for(int column = 0; column < arraysize; column++){
                if(line == column){
                    diagonals[0,column] = matrix[line,column];
                }
                if((line + column) == arraysize - 1){
                    diagonals[1, column] = matrix[line,column];
                }
            }
        }
        for(int i = 0; i < arraysize; i++){
            Console.WriteLine();
            Console.Write("first diagonal: {0} ", diagonals[0, i]);
            Console.WriteLine();
        }
        for(int j = 0; j < arraysize; j++){
            Console.WriteLine();
            Console.Write("second diagonal: {0} ", diagonals[1, j]);
            Console.WriteLine();
        } 
        return diagonals;
    }

    public static void FindsubMatrix(int[,] matrix){
        int arraysize =  matrix.GetLength(0);
        int sum = 0;

        for(int line = 1; line <= arraysize; line ++){
            for(int column = 1; column <= arraysize; column++){
                sum = (sum + (line * column));
            }
        }
        Console.WriteLine();
        Console.WriteLine("The matrix has {0} submatrices!", sum);
    }
}