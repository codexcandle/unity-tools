using UnityEngine;
using System.Collections;

public class FlyFocusCamController : MonoBehaviour
{
	public Transform target;

	public float moveSpeed = 50f;
	public float turnSpeed = 50f;

	void Update ()
	{
		// move
		// ... forward
		if(Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

		// ... backward
		if(Input.GetKey(KeyCode.DownArrow))
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

		// rotate
		// ... left
		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

		// ... right
		if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

		// ... down
		if(Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.left, -turnSpeed * Time.deltaTime);

		// ... up
		if(Input.GetKey(KeyCode.S))
			transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);

		// lean
		// ... left
		if(Input.GetKey(KeyCode.Q))
			transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime);

		// ... right
		if(Input.GetKey(KeyCode.W))
			transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime);

		transform.position += Input.GetAxis("Vertical") * 
								transform.forward * 
								moveSpeed * Time.deltaTime;
		
		transform.position += Input.GetAxis("Horizontal") * 
								transform.right * 
								moveSpeed * Time.deltaTime;

		float vDir = 0f;
		if(Input.GetKey("q"))
			vDir = 1;
		if(Input.GetKey("e")) 
			vDir = -1;
		transform.position += vDir *
								transform.up * 
								moveSpeed * Time.deltaTime;

		transform.LookAt(target);
	}
}