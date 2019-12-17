using UnityEngine;
using System.Collections.Generic;

namespace Codebycandle.Util.Instantiate.Destroy
{
	public class DestroyHelper:MonoBehaviour
	{
		public static void RemoveKids(Transform trans)
		{
			var kids = new List<GameObject>();
			foreach(Transform child in trans)
			{
				kids.Add(child.gameObject);
			}

			kids.ForEach(child => Destroy(child));
		}
	}
}