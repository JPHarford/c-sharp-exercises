// kata URL: https://www.codewars.com/kata/53d40c1e2f13e331fc000c26

using System.Collections.Generic;
using System.Numerics;
using System;

public class Fibonacci
{
    /*
    Using memoization and linear equations, we may calculate
    Fibonacci numbers in a performant manner.
    
    By definition, the nth fibonacci number, fib_n is given by

        fib_n = fib_n-1 + fib_n-2

    This holds for each n, so by substitution

        fib_n+1 = fib_n     + fib_n-1
                = fib_n-1   + fib_n-1   + fib_n-2
                = 2fib_n-1  + fib_n-2

    The same reasoning applies as we continue

        fib_n+2 = fib_n+1   + fib_n
                = 2fib_n-1  + fib_n-2   + fib_n-1   + fib_n-2
                = 3fib_n-1  + 2fib_n-2

        fib_n+3 = fib_n+2   + fib_n+1
                = 3fib_n-1  + 2fib_n-2  + 2fib_n-1  + fib_n-2
                = 5fib_n-1  + 3fib_n-2

    For the (n + m)th fibonacci number, we may use
    
      fib_n+m = fib_m+2 * fib_n-1 + fib_m+1 * fib_n-2.
      
    Table 1 shows m, fib_m+2, and fib_m+1 for n = 0 and
    m on the interval [0, 10].  The coefficients shown
    are themselves Fibonacci numbers.  Cached Fibonacci 
    numbers may be used for subsequent calculations.

        fibn+_ =  _ * fib_n-1     _ * fib_n-2
             0    1               1
             1    2               1
             2    3               2
             3    5               3
             4    8               5
             5    13              8
             6    21              13
             7    34              21
             8    55              34
             9    89              55
             10  144              89

      We therefore may apply memoization to calculate fib_n+m
      for arbitary m, so long as we use an integer type with large
      enough limits to handle the arithmetic.

      For example, suppose we have hard-coded fib_n for n on the
      interval [0, 10].  We may then calculating fib_20 using the
      Fibonacci numbers we've already cached.

          fib_20 = fib_12 * fib_9 + fib_11 * fib_8

      The higher we have previously calculated, the bigger leaps we
      may take to efficiently reach a target fib_n+m.  To achieve peak 
      optimization, a map is initialized with each fib_n on the interval 
      [0, 100], and each fib_a*10^b for a on [1, 10] and b on [2, 6], 
      with the exception that where b = 6, a is on [1, 2] -- since it's
      the two millionth Fibonacci challenge.
      
      These cached numbers may be used to find any fib_n with n on the 
      interval [-2 * 10^6, 2 * 10^6] by observing the pattern of 
      alternating sign for fib_n where n < 0.
    */
  
    // A static dictionary prevents superfluous calculation
    private static Dictionary<BigInteger,BigInteger> map;
  
    // A static constructor ensures our static dictionary is initialized
    static Fibonacci()
    {
        int orderOfMagnitude;
      
        BigInteger lastN;    // 10
        BigInteger lastNm1;  // 9
        BigInteger lastNm2;  // 8
        BigInteger lastNm3;  // 7
        BigInteger lastNm4;  // 6
        BigInteger lastNm5;  // 5
        BigInteger lastNm6;  // 4
        BigInteger lastNm7;  // 3
        BigInteger lastNm8;  // 2
        BigInteger lastNm9;  // 1
        BigInteger lastNm10; // 0  (or prior 10)
      
        BigInteger fib100i;   // Initially fib100
        BigInteger fib100im1; // Initially fib99
        BigInteger fib100im2; // Initially fib98

        BigInteger fib101;
        BigInteger fib102;
            
        // We initialize with the first 11 numbers
        map = new Dictionary<BigInteger,BigInteger>
        {
            {0, 0},
            {1, 1},
            {2, 1},
            {3, 2},
            {4, 3},
            {5, 5},
            {6, 8},
            {7, 13},
            {8, 21},
            {9, 34},
            {10, 55}
        };
      
        // Set fib_n for 10 < n < 101
        for(int i = 2; i < 11; i++)
        {
            // If we've already generated this, we can move on
            if(map.ContainsKey(i * 10)) continue;

            map.TryGetValue(10 * (i - 1), out lastN);
            map.TryGetValue(9 + 10 * (i - 2), out lastNm1);
            map.TryGetValue(8 + 10 * (i - 2), out lastNm2);
            map.TryGetValue(7 + 10 * (i - 2), out lastNm3);
            map.TryGetValue(6 + 10 * (i - 2), out lastNm4);
            map.TryGetValue(5 + 10 * (i - 2), out lastNm5);
            map.TryGetValue(4 + 10 * (i - 2), out lastNm6);
            map.TryGetValue(3 + 10 * (i - 2), out lastNm7);
            map.TryGetValue(2 + 10 * (i - 2), out lastNm8);
            map.TryGetValue(1 + 10 * (i - 2), out lastNm9);
            map.TryGetValue(10 * (i - 2), out lastNm10);

            map.Add
            (
              i * 10, 
              144 * lastNm1 + 89 * lastNm2
            );

            map.Add
            (
              9 + 10 * (i - 1),
              144 * lastNm2 + 89 * lastNm3
            );

            map.Add
            (
              8 + 10 * (i - 1),
              144 * lastNm3 + 89 * lastNm4
            );

            map.Add
            (
              7 + 10 * (i - 1),
              144 * lastNm4 + 89 * lastNm5
            );

            map.Add
            (
              6 + 10 * (i - 1),
              144 * lastNm5 + 89 * lastNm6
            );

            map.Add
            (
              5 + 10 * (i - 1),
              144 * lastNm6 + 89 * lastNm7
            );

            map.Add
            (
              4 + 10 * (i - 1),
              144 * lastNm7 + 89 * lastNm8
            );

            map.Add
            (
              3 + 10 * (i - 1),
              144 * lastNm8 + 89 * lastNm9
            );

            map.Add
            (
              2 + 10 * (i - 1),
              144 * lastNm9 + 89 * lastNm10
            );

            map.Add
            (
              1 + 10 * (i - 1),
              144 * lastNm8 - 55 * lastNm9 - 89 * lastNm10
            );
        }
      
        int stop;
      
        for(int i = 2; i < 7; i++)
        {
            if(i < 6) stop = 12;
            else stop = 3;
          
            orderOfMagnitude = (int) Math.Pow(10.0, (double) i);
          
            map.TryGetValue(orderOfMagnitude, out fib100i);
            map.TryGetValue(orderOfMagnitude - 1, out fib100im1);

            fib101 = fib100i + fib100im1;
            map.Add(orderOfMagnitude + 1, fib101);

            fib102 = fib101 + fib100i;
            map.Add(orderOfMagnitude + 2, fib102);

            // Set fib_n for 
            // (orderOfMagnitude/10) < n < orderOfMagnitude * (1 + 1/10) 
            // where n = orderOfMagnitude * j
            for(int j = 2; j < stop; j++)
            {
                map.TryGetValue(orderOfMagnitude * (j - 1) - 2, out fib100im2);
                map.TryGetValue(orderOfMagnitude * (j - 1) - 1, out fib100im1);
                map.TryGetValue(orderOfMagnitude * (j - 1), out fib100i);

                map.Add
                (
                  orderOfMagnitude * j,
                  fib102 * fib100im1 + fib101 * fib100im2
                );

                map.Add
                (
                  orderOfMagnitude * j - 1,
                  fib102 * fib100im2 + fib101 * (fib100im1 - fib100im2)
                );

                map.Add
                (
                  orderOfMagnitude * j - 2,
                  fib102 * (fib100im1 - fib100im2) + fib101 * (2 * fib100im2 - fib100im1)
                );
            }
        }
    }
  
    // Performs a decimal expansion of n
    public static int[] decimalExpansion(in int n)
    {
        int remaining = n;
        double power = Math.Truncate(Math.Log((double)remaining)/Math.Log(10));
        double orderOfMagnitude = Math.Pow(10.0, power);
      
        // power = 0 where 0 <= n <= 9
        int[] sequence = new int[(int)power + 1];
      
        while (remaining > 0)
        {
            sequence[(int) power] = (int) 
            (
              Math.Truncate(remaining / orderOfMagnitude)
            );
              
            remaining -= sequence[(int) power] * (int) orderOfMagnitude;            
            power = Math.Truncate(Math.Log((double)remaining)/Math.Log(10));
            orderOfMagnitude = Math.Pow(10.0, power);
        }
      
        return sequence;
    }
  
    // Uses previously calculated n to find fib_n where n % 10 != 0 and n > 100.
    public static BigInteger CalculateFibN 
    (
        in int n, 
        in bool neg, 
        in bool even, 
        in int[] expandedN
    )
    {
        BigInteger resultant;
        BigInteger fibMp1;
        BigInteger fibMp2;
          
        int lastN = expandedN[0] + 10 * expandedN[1];
        if(lastN < 3) lastN += 100;
      
        int marchingN;
      
        int orderOfMagnitude;
        int nextOrderOfMagnitude;
        int stop;
      
        BigInteger fibN;
        BigInteger fibNm1;
        BigInteger fibNm2;
      
        for(int i = 2; i < expandedN.Length; i++)
        {
            orderOfMagnitude = (int) Math.Pow(10.0, (double) i);
            nextOrderOfMagnitude = (int) Math.Pow(10.0, (double) (i + 1));
          
            marchingN = lastN;
            stop = lastN + expandedN[i] * orderOfMagnitude;
            
            map.TryGetValue(orderOfMagnitude + 1, out fibMp1);
            map.TryGetValue(orderOfMagnitude + 2, out fibMp2);
          
            for
            (
              int j = marchingN; 
              j < stop; 
              j = marchingN
            )
            {
                map.TryGetValue(marchingN, out fibN);
                map.TryGetValue(marchingN - 1, out fibNm1);
                map.TryGetValue(marchingN - 2, out fibNm2);

                if(!map.ContainsKey(marchingN + orderOfMagnitude))
                {
                    map.Add
                    (
                      marchingN + orderOfMagnitude,
                      fibMp2 * fibNm1 + fibMp1 * fibNm2
                    );
                }

                if(!map.ContainsKey(marchingN - 1 + orderOfMagnitude))
                {
                  map.Add
                  (
                    marchingN - 1 + orderOfMagnitude,
                    fibMp2 * fibNm2 + fibMp1 * (fibNm1 - fibNm2)
                  );
                }

                if(!map.ContainsKey(marchingN - 2 + orderOfMagnitude))
                {
                    map.Add
                    (
                      marchingN - 2 + orderOfMagnitude,
                      fibMp2 * (fibNm1 - fibNm2) + fibMp1 * (2 * fibNm2 - fibNm1)
                    );
                }

                marchingN += orderOfMagnitude;
            }
          
            if(map.ContainsKey(n)) break;
          
            lastN += expandedN[i] * orderOfMagnitude;
            map.TryGetValue(lastN, out fibN);
        }
      
        map.TryGetValue(n, out resultant);
        System.Console.WriteLine("fib_" + (n * (neg ? -1 : 1)) + " = " + (resultant * (neg ? -1 : 1)));
        return resultant * (neg && even ? -1 : 1);
    }
  
    // Finds fib_n using read-only n
    public static BigInteger fib(in int n)
    {
      bool neg = n < 0;
      bool even = n % 2 == 0;
      int nRW = n; 
      if(neg) nRW *= -1;
      
      // If we've already generated this, we can just return it
      if(map.ContainsKey(nRW))
      {
        BigInteger resultant;
        map.TryGetValue(nRW, out resultant);
        System.Console.WriteLine("fib_" + n + " = " + (resultant * (neg && even ? -1 : 1)));
        return resultant * (neg && even ? -1 : 1);
      }
      
      return CalculateFibN(nRW, neg, even, decimalExpansion(n));
    }
}
