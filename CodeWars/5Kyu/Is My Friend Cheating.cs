// kata URL: https://www.codewars.com/kata/5547cc7dcad755e480000004

using System.Collections.Generic;

public class RemovedNumbers {
  public static List<long[]> removNb(long n) {
    
    List<long[]> output = new List<long[]>();
    
    long gross = (n * (1+n))/2;
    long solution;
    
    for(long i = 1; i <= n; i++)
    {
      if((gross - i)%(i + 1) != 0 || (gross - i)/(i + 1) > n) continue; 
      
      output.Add(new long[2] {i,(gross - i)/(i + 1)});
    }
      
    return output;
  }
}
