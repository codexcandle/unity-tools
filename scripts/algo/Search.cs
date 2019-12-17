// SOURCE:  ?
// PURPOSE: "search" algorithms
using System.Collections;
using System.Collections.Generic;

namespace codebycandle.util.algo
{
    static public class Search
    {
        static public object BinarySearchRecursive(int[] arr, int key, int min, int max)
        {
            if(min > max)
            {
                return "Nil";
            }
            else
            {
                int midIndex = (min + max) / 2;
                int midVal = arr[midIndex];

                if (key == midVal)
                {
                    return midIndex;
                }
                else if (key < midVal)
                {
                    return BinarySearchRecursive(arr, key, min, midIndex - 1);
                }
                else
                {
                    return BinarySearchRecursive(arr, key, midIndex + 1, max);
                }
            }
        }

        static public int BinarySearchIterative(int[] arr, int key)
        {
            int min = 0;
            int max = arr.Length - 1;

            // sanitize! - ensure sorted array is initially passed
            for(int i = 1; i <= max; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    // data is not sorted!
                    return -1;
                }
            }

            // search!
            while(min <= max)
            {
                int midIndex = (min + max) / 2;
                int midVal = arr[midIndex];
                if (key == midVal)
                {
                    return midIndex;
                }
                else if (key < midVal)
                {
                    max = midIndex - 1;
                }
                else
                {
                    min = midIndex + 1;
                }
            }

            return -1;
        }

        static public bool SearchForDupes(IList<int> elements)
        {
            int length = elements.Count;
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    // don't compare with self
                    if(i == j) continue;

                    if(elements[i] == elements[j]) return true;
                }
            }

            return false;
        }

        /*
        // TODO - confirm if still broken?
        static public bool SearchToConfirmBracketBalance(string str)
        {
            Stack stack = new Stack();

            foreach(char c in str)
            {
                if(c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                else if (c == '}' || c == ']' || c == ')')
                {
                    // check if c == COUNTERPART to top item on stack
                    string stackChar = stack.Peek().ToString();

                    // attempt to get counter-char
                    string charString = GetCharCounterpart(stackChar);

                    if(stackChar == charString[0])
                    {

                    }
                }
            }


            return (stack.Count == 0);
        }
        */
    }
}