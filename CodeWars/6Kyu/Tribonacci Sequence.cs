// kata URL: https://www.codewars.com/kata/556deca17c58da83c00002db

public class Xbonacci
{
  public double[] Tribonacci(double[] signature, int n)
  {
    double[] resultant = new double[n];
    
    for(int i = 0; i < 3 && i < n; i++)
    {
      resultant[i] = signature[i];  
    }
    
    for(int i = 3; i < n; i++)
    {
      resultant[i] = resultant[i - 3] + resultant[i - 2] + resultant[i - 1]; 
    }
    
    return resultant;
  }
}
