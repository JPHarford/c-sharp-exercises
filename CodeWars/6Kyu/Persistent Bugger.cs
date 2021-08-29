// kata URL: https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec

using System;

public class Persist 
{
  public static int Persistence(long n, int resultant = 0) 
  {
    // Char.GetNumericValue() returns a double, which then requires a cast
    // Because we know we are getting single-digit ints, a switch may be
    // more performant.
    //
    // This solution uses recursion.
    
    char[] digits = n.ToString().ToCharArray();
    if(digits.Length == 1) return resultant;
    
    int value = 0;
    long product = 1;
    
    for(int i = 0; i < digits.Length; i++) 
    {
      if(GetNumericValue(ref value, digits[i]))
        product *= value;
    }
    
    return Persistence(product, resultant + 1);
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
