// kata URL: https://www.codewars.com/kata/554b4ac871d6813a03000035

using System;

public static class Kata
{
  public static string HighAndLow(string numbers)
  {
    var split = numbers.Split(' ');
    
    int parsed = 0;
    
    int greatestValueIndex = 0;
    int greatestValue = 0;
    
    int leastValueIndex = 0;
    int leastValue = 0;
    
    string resultant = "";
    
    for(int i = 0; i < split.Length; i++)
    {
      if(!Int32.TryParse(split[i], out parsed)) continue;
      
      if(parsed >= greatestValue)
      {
        greatestValueIndex = i;
        greatestValue = parsed;
      }
       
      if(parsed <= leastValue)
      {
        leastValueIndex = i;
        leastValue = parsed;
      }
    }
    
    resultant += split[greatestValueIndex] + ' ' + split[leastValueIndex];
    
    return resultant;
  }
}
