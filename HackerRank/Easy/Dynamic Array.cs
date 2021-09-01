using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
        NOTE: This is edited from the original formulation that
        included a superfluous parameter n in the signature for
        dynamicArray().  
    */
    
    /*
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static List<int> dynamicArray(List<List<int>> queries)
    {
        int idx;
        int lastAnswer = 0;
        
        List<List<int>> arr = new List<List<int>>(queries[0][0]);
        List<int> answers = new List<int>(queries[0][0]);
        
        for(int i = 1; i < queries.Count; i++)
        {
            idx = (queries[i][1] ^ lastAnswer) % queries[0][0];
            
            if(arr.Count < idx + 1) 
                for(int j = arr.Count; j < idx + 1; j++) 
                    arr.Add(new List<int>());
            
            if(queries[i][0] == 2)
            {
                lastAnswer = arr[idx][queries[i][2] % arr[idx].Count];
                answers.Add(lastAnswer);
            }
            else arr[idx].Add(queries[i][2]);
        }
        
        return answers;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = Result.dynamicArray(queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
