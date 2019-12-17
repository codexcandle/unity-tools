// SOURCE:  ?
// PURPOSE: "fibonacci" algorithms
namespace codebycandle.util.algo
{
    using UnityEngine;

    public static class Fibonacci
    {
        public const string ALGORITHM_TYPE_ITERATIVE = "iterative";
        public const string ALGORITHM_TYPE_RECURSIVE = "recursive";

        #region VALUE-ITERATIVE
        static public int GetValueIterative(int numPos)
        {
            /*
            E.G. - Write a method `Fib` that takes an integer `n` 
            & returns the `nth` Fibonacci number.

            Let's say our Fibonacci series is 0-indexed & starts with `0`:

	        Fib(0);  // => 0
	        Fib(1);  // => 1
	        Fib(2);  // => 1
	        Fib(3);  // => 2
	        Fib(4);  // => 3
            */

            int index = numPos - 1;

            int[] fib = new int[numPos];
            fib[0] = 0;
            fib[1] = 1;

            for(int i = 2; i <= index; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[index];

            /* FYI - another way!
            ===============================
            int prev = -1;
            int next = 1;
            int sum = -1;

            for (int i = 0; i < numPos; i++)
            {
                sum = next + prev;

                prev = next;
                next = sum;
            }

            return sum;
            ===============================
            */
        }
        #endregion

        #region VALUE-RECURSIVE
        static public int GetValueRecursive(int index)
        {
            // NOTE:  "index" value here, vs. "numPos" input for all other methods
            // TODO - see if can convert to "numPos"
            if(index <= 0)
            {
                return 0;
            }
            else if(index == 1)
            {
                return 1;
            }
            else
            {
                return GetValueRecursive(index - 1) + GetValueRecursive(index - 2);
            }
        }
        #endregion

        #region SERIES-ITERATIVE
        static public int[] GetSeriesIterative(int n)
        {
            /*
            * e.g.
            * GetSeriesIterative(9);
            * 0, 1, 1, 2, 3, 5, 8, 13, 21...
            */

            int a = 0, b = 1, c = 0;
            int[] data = new int[n];
            int dataPos = 0;

            data[dataPos] = a;
            dataPos++;

            if (n == 0) return data;

            data[dataPos] = b;
            dataPos++;

            if (n == 1) return data;

            for(int i= 2; i < n; i++)
            {
                c = a + b;

                data[dataPos] = c;
                dataPos++;

                a = b;
                b = c;
            }

            return data;
        }
        #endregion

        #region SERIES-RECURSIVE
        static public void PrintSeriesRecursive(int len)
        {
            // TODO - make this RETURN values (not just print them!)

            /*
            * e.g.
            * FibonacciSeriesRecursive(11);
            * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55...
            */

            PrintMemberRecursive(0, 1, 1, len);
        }

        static private void PrintMemberRecursive(int a, int b, int counter, int len)
        {
            if (counter <= len)
            {
                Debug.Log(a);

                PrintMemberRecursive(b, a + b, counter + 1, len);
            }
        }
        #endregion
    }
}