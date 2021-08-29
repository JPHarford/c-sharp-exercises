// kata URL: https://www.codewars.com/kata/5264d2b162488dc400000001

using System;
using System.Collections;
using System.Text;

public class Kata
{
  public static string SpinWords(string sentence)
  {
    char[][] words = Decompose(sentence);
    
    for(int i = 0; i < words.Length; i++)
    {
      if(words[i].Length < 5) continue;
      
      words[i] = Reverse(words[i]);
    }
    
    return Rebuild(words);
  }
  
  public static string Rebuild(char[][] words)
  {
    string sentence = "";
    int i = 0;
    
    foreach(char[] word in words)
    {
      sentence += string.Join("", word);
      
      if(i < words.Length - 1) sentence += " ";
      i++;
    }
    
    return sentence;
  }
  
  public static char[] Reverse(char[] word)
  {
      char[] reversed = new char[word.Length];
      
      for(int i = 0; i < word.Length; i++)
        reversed[i] = word[word.Length - 1 - i];
      
      return reversed;
  }
  
  public static char[][] Decompose(string sentence)
  {
    string[] split = sentence.Split(' ');
    char[][] words = new char[split.Length][];
    
    for(int i = 0; i < split.Length; i++) words[i] = split[i].ToCharArray();
    
    return words;
  }
}
