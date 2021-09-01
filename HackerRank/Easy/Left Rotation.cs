// Problem URL: https://www.hackerrank.com/challenges/array-left-rotation/problem

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'rotateLeft' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */

    public static List<int> rotateLeft(int d, List<int> arr)
    {
        int[] resultant = new int[arr.Count];
        
        for(int i = 0; i < arr.Count; i++)
        {
            resultant[i >= d ? i - d : arr.Count + i - d] = arr[i];
        }
        
        return resultant.ToList();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.rotateLeft(d, arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
