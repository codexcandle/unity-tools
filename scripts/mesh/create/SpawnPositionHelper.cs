using System.Collections.Generic;
using UnityEngine;

namespace Codebycandle.Util.Tform
{
    public class SpawnPositionHelper:MonoBehaviour
    {
        public static List<GameObject> SpawnElipsoid(GameObject pointPrefab, int numPoints, Vector3 centerPos, Transform targetParent, bool vertical)
        {
            List<GameObject> items = new List<GameObject>();

            float radiusX = 10f;
            float radiusY = 10F;                        // radii for each x,y axes, respectively

            bool isCircular = false;                    // is the drawn shape a complete circle?

            //position to place each prefab along the given circle/eliptoid
            //*is set during each iteration of the loop
            Vector3 pointPos = new Vector3(0, 0, 0);

            // instantiate
            for (int i = 0; i < numPoints; i++)
            {
                //multiply 'i' by '1.0f' to ensure the result is a fraction
                float pointNum = (i * 1.0f) / numPoints;

                //angle along the unit circle for placing points
                float angle = pointNum * Mathf.PI * 2;

                float x = Mathf.Sin(angle) * radiusX;
                float y = Mathf.Cos(angle) * radiusY;

                //position for the point prefab
                if(vertical)
                {
                    pointPos = new Vector3(x, y) + centerPos;
                }
                else if(!vertical)
                {
                    pointPos = new Vector3(x, 0, y) + centerPos;
                }

                //place the prefab at given position
                GameObject item = Instantiate(pointPrefab, pointPos, Quaternion.identity);

                // set parent
                item.transform.SetParent(targetParent);

                // save
                items.Add(item);
            }

            //keeps radius on both axes the same if circular
            if (isCircular)
            {
                radiusY = radiusX;
            }

            return items;
        }

        public static List<GameObject> SpawnAroundTarget(float points, GameObject prefab, Transform target)
        {
            List<GameObject> items = new List<GameObject>();

            // TODO - make this a param?
            int size = 8;

            float increment = Mathf.PI * (3 - Mathf.Sqrt(5));
            float offset = 2 / points;
            for (float i = 0; i < points; i++)
            {
                float y = i * offset - 1 + (offset / 2);
                float radius = Mathf.Sqrt(1 - y * y);
                float angle = i * increment;
                Vector3 pos = new Vector3((Mathf.Cos(angle) * radius * size), y * size, Mathf.Sin(angle) * radius * size);

                // Create the object as a child of the sphere
                GameObject child = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
                child.transform.parent = target;

                items.Add(child);
            }

            return items;
        }

        public static void SpawnAtRandomPosAroundTarget(GameObject parentSphere, GameObject prefab)
        {
            Vector3 spawnPosition = Random.onUnitSphere * ((parentSphere.transform.localScale.x / 2) + prefab.transform.localScale.y * 0.5f) + parentSphere.transform.position;

            GameObject go = Instantiate(prefab, spawnPosition, Quaternion.identity) as GameObject;
            go.transform.LookAt(parentSphere.transform);
            go.transform.Rotate(-90, 0, 0);
        }
    }
}