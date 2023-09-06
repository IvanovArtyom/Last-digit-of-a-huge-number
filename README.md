## Description:
For a given list ```[x1, x2, x3, ..., xn]``` compute the last (decimal) digit of ```x1 ^ (x2 ^ (x3 ^ (... ^ xn)))```.

E. g., with the input ```[3, 4, 2]```, your code should return ```1``` because ```3 ^ (4 ^ 2) = 3 ^ 16 = 43046721```.

*Beware:* powers grow incredibly fast. For example, ```9 ^ (9 ^ 9)``` has more than 369 millions of digits. ```lastDigit``` has to deal with such numbers efficiently.

*Corner cases:* we assume that ```0 ^ 0 = 1``` and that ```lastDigit``` of an empty list equals to 1.

This kata generalizes [Last digit of a large number](https://www.codewars.com/kata/5511b2f550906349a70004e1/csharp); you may find useful to solve it beforehand.
### My solution
``` C#
using System;

namespace Solution
{
    public class Calculator
    {
        public static int LastDigit(int[] array)
        {
            if (array.Length < 1)
                return 1;

            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] == 0)
                    array[i - 1] = 1;

                if (array[i] == 0 || array[i] == 1)
                    Array.Resize(ref array, i);
            }

            if (array.Length == 1)
                return array[0] % 10;

            int n0 = array[0] % 10, n1 = array[1] % 8 == 0 ? 8 : array[1] % 8;

            if (array.Length == 2)
                return (int)Math.Pow(n0, n1) % 10;

            if (n0 == 0 || n0 == 1 || n0 == 5 || n0 == 6 || n1 == 1 || n1 == 5 || n1 == 9)
                return n0;

            if (n0 % 2 == 0 && n1 % 2 == 0)
                return 6;

            if (n0 % 2 == 1 && n1 % 2 == 0)
                return 1;

            int n2 = array[2] % 2;

            if ((n1 == 3 || n1 == 7) && n2 == 1)
            {
                return n0 switch
                { 
                    2 => 8,
                    3 => 7,
                    7 => 3,
                    8 => 2,
                    _ => n0
                };
            }

            return n0;
        }
    }
}
```
