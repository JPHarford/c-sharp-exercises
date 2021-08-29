using System.Collections.Generic;
using System.Linq;

public class RomanNumerals
{
    public static int Enumerate(char c)
    {
      switch(c)
      {
        case 'I': { return 1; break;   }
        case 'V': { return 5; break;   }
        case 'X': { return 10; break;  }
        case 'L': { return 50; break;  }
        case 'C': { return 100; break; }
        case 'D': { return 500; break; }
        case 'M': { return 1000; break;}
        default: {break;}
      }
      
      return 0;
    }
  
    public static string Denumerate(int place, int digit)
    {
      
        switch (place)
        {
          case 0:
            {
              switch(digit)
              {
                case 1:
                  {
                    return "I";
                    break;
                  }
                case 2:
                  {
                    return "II";
                    break;
                  }
                case 3:
                  {
                    return "III";
                    break;
                  }
                case 4:
                  {
                    return "IV";
                    break;
                  }
                case 5:
                  {
                    return "V";
                    break;
                  }
                case 6:
                  {
                    return "VI";
                    break;
                  }
                case 7:
                  {
                    return "VII";
                    break;
                  }
                case 8:
                  {
                    return "VIII";
                    break;
                  }
                case 9:
                  {
                    return "IX";
                    break;
                  }
                default:
                  {
                    break;
                  }
              }
              break;
            }
          case 1:
            {
              switch(digit)
              {
                case 1:
                  {
                    return "X";
                    break;
                  }
                case 2:
                  {
                    return "XX";
                    break;
                  }
                case 3:
                  {
                    return "XXX";
                    break;
                  }
                case 4:
                  {
                    return "XL";
                    break;
                  }
                case 5:
                  {
                    return "L";
                    break;
                  }
                case 6:
                  {
                    return "LX";
                    break;
                  }
                case 7:
                  {
                    return "LXX";
                    break;
                  }
                case 8:
                  {
                    return "LXXX";
                    break;
                  }
                case 9:
                  {
                    return "XC";
                    break;
                  }
                default:
                  {
                    break;
                  }
              }
              break;
            }
          case 2:
            {
              switch(digit)
              {
                case 1:
                  {
                    return "C";
                    break;
                  }
                case 2:
                  {
                    return "CC";
                    break;
                  }
                case 3:
                  {
                    return "CCC";
                    break;
                  }
                case 4:
                  {
                    return "CD";
                    break;
                  }
                case 5:
                  {
                    return "D";
                    break;
                  }
                case 6:
                  {
                    return "DC";
                    break;
                  }
                case 7:
                  {
                    return "DCC";
                    break;
                  }
                case 8:
                  {
                    return "DCCC";
                    break;
                  }
                case 9:
                  {
                    return "CM";
                    break;
                  }
                default:
                  {
                    break;
                  }
              }
              break;
            }
          case 3:
            {
              switch(digit)
              {
                case 1:
                  {
                    return "M";
                    break;
                  }
                case 2:
                  {
                    return "MM";
                    break;
                  }
                case 3:
                  {
                    return "MMM";
                    break;
                  }
                case 4:
                  {
                    return "MMMM";
                    break;
                  }
                default:
                  {
                    break;
                  }
              }
              break;
            }
          default:
            {
              break;
            }
        }
      
        return "";
    }
  
    public static void CollectDigit(ref int resultant, in List<int> digit)
    {
        resultant += digit[digit.Count - 1];
      
        if(digit.Count == 1) return;
      
        digit[digit.Count - 1] = 0;
        resultant -= digit.Sum();
    }
  
    public static int PopLeftDigit(ref int n, in int power)
    {
      int digit = (int)System.Math.Truncate((double)n/System.Math.Pow(10, power));
      if(n > 0) n -= digit * (int) System.Math.Pow(10, power);
      
      return digit;
    }
  
    public static string ToRoman(int n)
    {
        string resultant = "";
        List<int> digits = new List<int>();
        
        int power = (int)System.Math.Truncate(System.Math.Log(n));
      
        for(int i = power;i > -1;i--)
        {
          if(n == 0) System.Console.WriteLine(i + ", " + 0);
          digits.Add(n > 0 ? PopLeftDigit(ref n, i) : 0);
        }
      
        for(int i = digits.Count - 1; i >= 0; i--)
        {
            resultant += Denumerate(i, digits[digits.Count - i - 1]);
        }
        
        return resultant;
    }

    public static int FromRoman(string romanNumeral)
    {
        List<int> digit = null;
        int resultant = 0;
      
        int current;
        int prior = 10000;
        
        char[] raw = romanNumeral.ToCharArray();
      
        if(raw.Length == 1) return Enumerate(raw[0]);
      
        for(int i = 0; i < raw.Length; i++)
        {
          current = Enumerate(raw[i]);
          
          if(current != prior)
          {
            if(current < prior)
            {
              if(i > 0) CollectDigit(ref resultant, digit);

              digit = new List<int>();
            }
            
            digit.Add(current);
          }
          else digit[digit.Count - 1] += current;
          
          if(i == raw.Length - 1) CollectDigit(ref resultant, digit);
          else prior = current;
        }
      
        return resultant;
    }
  }
