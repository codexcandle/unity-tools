using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: NaturalDocsTestScript
// Demo script to test out the Unity plugin _Natural Docs_ for project docu.
public class NaturalDocsTestScript : MonoBehaviour
{
    // EX-1: SIMPLE
    /////////////////////////////////
    // Function: DoFunStuff
    // Like dance & stuff!
    public int DoFunStuff(int x, string b)
    {
        return 39;
    }

    // EX-2: ADVANCED
    /////////////////////////////////
    /* Function: Multiply

    Multiplies two integers.

    Parameters:

        x - The first integer.
        y - The second integer.

    Returns:

        The two integers multiplied together.

    See Also:

        <DoFunStuff>
    */
    private int Multiply(int x, int y)
    {
        return x * y;
    }
}
