// SOURCE:  Unity VR Book
// FUNCTION:  Simple timed-destroy.
using UnityEngine;
using System.Collections;

namespace Codebycandle.Util.Instantiate
{
	public class DestroyTimeout:MonoBehaviour
	{
		public float time = 5.0F;

		void Start()
		{
			Destroy(gameObject, time);
		}
	}
}