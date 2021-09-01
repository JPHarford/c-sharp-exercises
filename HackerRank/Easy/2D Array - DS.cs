// Problem URL: https://www.hackerrank.com/challenges/2d-array/problem

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
        int greatest = -100;
        int sum;
        
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] 
                    + arr[i + 1][j + 1]
                    + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    
                greatest = sum > greatest ? sum : greatest;
            }
        }
        
        return greatest;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

}
