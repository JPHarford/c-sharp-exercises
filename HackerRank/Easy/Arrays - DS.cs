// Problem URL: https://www.hackerrank.com/challenges/arrays-ds/problem

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'reverseArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static List<int> reverseArray(List<int> a)
    {
        List<int> resultant = new List<int>(a.Count);
        
        /* 
        // Linq Solution: Not verbose, but not performant.
        
        resultant.AddRange
        ( // Copied Once
            ( // Copied Twice
                from i in a
                orderby a.IndexOf(i) descending
                select i
            ).ToArray() // Copied THRICE!
        );
        */
        
        // Copied Once
        for(int i = a.Count - 1; i > -1; i--) resultant.Add(a[i]);
        
        return resultant;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> res = Result.reverseArray(arr);

        textWriter.WriteLine(String.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
