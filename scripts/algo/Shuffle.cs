// SOURCE:  ?
// PURPOSE: "shuffling" algorithm
namespace codebycandle.util.algo
{
    using UnityEngine;

    static public class Shuffle
    {
        static public void DoShuffle(int[] arr)
        {
            int length = arr.Length;
            for(int i = 0; i < length; i++)
            {
                int tempVal = arr[i];
                int randVal = Random.Range(0, length);

                arr[i] = arr[randVal];
                arr[randVal] = tempVal;
            }

            return;
        }
    }
}