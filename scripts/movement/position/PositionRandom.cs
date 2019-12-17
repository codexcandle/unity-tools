using UnityEngine;
using System.Collections;

namespace Codebycandle.Util.Tform
{
    // SOURCE:  	Unity5 VR Book (Unity Virtual Reality Projects)
    // NAME:		PositionRandom
    // FUNCTION:	Randomly positions a game object.
    // NOTE:  		Only applying to X + Z planes below.
    public class PositionRandom:MonoBehaviour
	{
		void Start()
		{
			StartCoroutine(RePositionWithDelay());
		}

		IEnumerator RePositionWithDelay()
		{
			while(true)
			{
				SetRandomPosition();

				yield return new WaitForSeconds(5);
			}
		}

		void SetRandomPosition()
		{
			float x = Random.Range (-5.0f, 5.0f);
			float z = Random.Range (-5.0f, 5.0f);

			UnityEngine.Debug.Log ("X,Z: " + x.ToString("F2") + ", " + z.ToString("F2"));

			transform.position = new Vector3(x, 0.0f, z);
		}
	}
}