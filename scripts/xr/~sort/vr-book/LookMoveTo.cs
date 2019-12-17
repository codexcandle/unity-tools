// SOURCE:  	Unity5 VR Book (Unity Virtual Reality Projects)
// NAME:		LookMoveTo
// FUNCTION:	Move "this object" to where camera gaze intersects "ground."
using UnityEngine;
using System.Collections;

public class LookMoveTo:MonoBehaviour
{
	public GameObject ground;

	void Update()
	{
		Transform camera = Camera.main.transform;
		Ray ray;
		RaycastHit hit;
		GameObject hitObject;
	   
		Debug.DrawRay (camera.position,
	   
		camera.rotation * Vector3.forward * 100.0f);
	   
		ray = new Ray (camera.position, camera.rotation * Vector3.forward);
		if(Physics.Raycast(ray, out hit))
		{
			hitObject = hit.collider.gameObject;
			if(hitObject == ground)
			{
	    		Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
	       
	    		transform.position = hit.point;
	   		}
		}

		/*
			// .... OR IF YOU WANT TO HIT SOMETHING "IN IN VISIBLE LINE" - raycastALL!
			Transform camera = Camera.main.transform; Ray ray;
			RaycastHit[] hits;
			GameObject hitObject;
			       Debug.DrawRay (camera.position, camera.rotation *
			         Vector3.forward * 100.0f);
			       ray = new Ray (camera.position, camera.rotation *
			         Vector3.forward);
			       hits = Physics.RaycastAll (ray);

			for (int i = 0; i < hits.Length; i++) { RaycastHit hit = hits [i];
			hitObject = hit.collider.gameObject; if (hitObject == ground) {
			           Debug.Log ("Hit (x,y,z): " +
			             hit.point.ToString("F2"));
			           transform.position = hit.point;
			         }
			}

	
			// ---- !!!!!!!
			// HOWEVER! - more efficient!
			- use layer system. Create a new layer, assign it to the 
			plane, and pass it as an argument to Physics.raycast()
		*/
	}
}