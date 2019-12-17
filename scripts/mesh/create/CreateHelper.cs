using UnityEngine;
using System;

namespace Codebycandle.Util.Make
{
	public class CreateHelper:MonoBehaviour
	{
		public static void CreateGrid(GameObject prefab, int gridX = 5, int gridY = 5, float spacing = 2f)
		{
			for(int y = 0; y < gridY; y++)
			{
				for(int x = 0; x < gridX; x++)
				{
					Vector3 pos = new Vector3(x, 0, y) * spacing;
					Instantiate(prefab, pos, Quaternion.identity);
				}
			}
		}

		public static void CreateCircle(GameObject prefab, int count = 20, float radius = 5f)
		{
			for(int i = 0; i < count; i++)
			{
				float angle = i * (float)Math.PI * 2 / count;
				Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
				Instantiate(prefab, pos, Quaternion.identity);
			}
		}				
	}
}