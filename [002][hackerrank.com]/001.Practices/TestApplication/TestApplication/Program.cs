using System;
using System.IO;

class Solution
{
    // Complete the diagonalDifference function below.
    static int diagonalDifference(int[][] arr)
    {
        var row = 1;
        var left = 0;
        var N = arr[0][0];
        var right = N - 1;
        var result = 0;

        while (row <= N)
        {
            result += arr[row][left] - arr[row][right];
            row++;
            left++;
            right--;
        }

        return Math.Abs(result);
    }

    static void Main(string[] args)
    {
        var arr = new int[][]
        {
            new[] { 3 },
            new[] { 11, 2, 4 },
            new[] { 4, 5, 6 },
            new[] { 10, 8, -12 }
        };

        int result = diagonalDifference(arr);

        Console.WriteLine(result);
    }
}
