using System;

namespace Solution
{
    public class Calculator
    {
        public static void Main()
        {
            // Test
            var t1 = LastDigit(new int[] { 2, 2, 2, 0 });
            // ...should return 4
        }

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