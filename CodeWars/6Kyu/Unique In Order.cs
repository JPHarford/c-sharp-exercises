// kata URL: https://www.codewars.com/kata/54e6533c92449cc251001667

using System.Collections.Generic;

public static class Kata
{
  public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) 
  {
    List<T> resultant = new List<T>();
    T previousUnique = default(T);
    
    foreach(var element in iterable)
    {
      if(!element.Equals(previousUnique))
      {
        previousUnique = element;
        resultant.Add(element);
      }
    }
    
    return resultant;
  }
}
