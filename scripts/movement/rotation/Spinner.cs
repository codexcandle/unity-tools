namespace Codebycandle.Util.Movment
{
	using UnityEngine;

	public class Spinner:MonoBehaviour
	{
		public float xRate = 0f;	// degrees / sec
		public float yRate = 20f;
		public float zRate = 0f;

		void Update()
		{
			transform.Rotate(new Vector3(xRate, yRate, zRate) * Time.deltaTime);

			// or
			// #2
			// transform.Rotate(0.0f, 40.0f * Time.deltaTime, 0.0f);

			// or
			// #3
			// transoform.Rotate(Vector3.up, speed  * Time.deltaTime);
		}
	}
}