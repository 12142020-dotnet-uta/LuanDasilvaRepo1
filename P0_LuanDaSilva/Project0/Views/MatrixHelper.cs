using System;


namespace Views
{
    public class MatrixHelper
    {
        
//helper to generate matrix
    public static int[,] generateMatrix(int x){
        int[,] array = new int[x, x];
        return array;

}//end generator helper


//helper to print matrix
     public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }// matrix printer helper

    }
}