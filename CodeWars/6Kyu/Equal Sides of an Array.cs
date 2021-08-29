// kata URL: https://www.codewars.com/kata/5679aa472b8f57fb8c000047

public class Kata
{
  
  public static int SumsLeft(int[] arr, int i)
  {
      int resultant = 0;
        
      for(int j = 0; j < i; j++)
      {
        resultant += arr[j];
      }
    
      return resultant;
  }
  
  public static int SumsRight(int[] arr, int i)
  {
    int resultant = 0;
    
    for(int j = arr.Length - 1; j > i; j--)
    {
      resultant += arr[j];
    }
    
    return resultant;
  }
  
  public static int FindEvenIndex(int[] arr)
  {
    for(int i = 0; i < arr.Length; i++)
    {
        if(SumsLeft(arr, i) == SumsRight(arr, i)) return i;
    }
    
    return -1;
  }
}
