using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CursorPositioner : MonoBehaviour
{
	private float defaultPosZ;

	void Start()
	{
		defaultPosZ = transform.localPosition.z;
	}

	void Update()
	{
		Transform camera = Camera.main.transform;
		Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit))
		{
			float z = (hit.distance <= defaultPosZ) ?  hit.distance : defaultPosZ;
			transform.localPosition = new Vector3 (0, 0, z);
		}
	}
}