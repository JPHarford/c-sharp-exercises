// kata URL: https://www.codewars.com/kata/546e2562b03326a88e000020

using System;

public class Kata
{
  public static int SquareDigits(int n)
  {
    char[] nArray = n.ToString().ToCharArray();
    int square = 0;
    string resultant = "";
    
    foreach (char c in nArray)
    {

      if(GetNumericValue(ref square, c))
      {
        square *= square;
        resultant += square;
      }
    }
    
    return Int32.Parse(resultant);
  }
  
  public static bool GetNumericValue(ref int i, in char c)
  {
    switch(c)
    {
      case '0':
        {
          i = 0;
          return true;
          break;
        }
      case '1':
        {
          i = 1;
          return true;
          break;
        }
      case '2':
        {
          i = 2;
          return true;
          break;
        }
      case '3':
        {
          i = 3;
          return true;
          break;
        }
      case '4':
        {
          i = 4;
          return true;
          break;
        }
      case '5':
        {
          i = 5;
          return true;
          break;
        }
      case '6':
        {
          i = 6;
          return true;
          break;
        }
      case '7':
        {
          i = 7;
          return true;
          break;
        }
      case '8':
        {
          i = 8;
          return true;
          break;
        }
      case '9':
        {
          i = 9;
          return true;
          break;
        }
      default:
        {
          return false;
        }
      }
  }
}
