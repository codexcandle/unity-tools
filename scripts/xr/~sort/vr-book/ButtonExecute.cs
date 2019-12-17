using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonExecute:MonoBehaviour
{
	private GameObject currentButton;
	private Clicker clicker = new Clicker ();

	public float timeToSelect = 2.0f;
	private float countDown;

	void Update()
	{
		Transform camera = Camera.main.transform;
		Ray ray = new Ray (camera.position, camera.rotation * Vector3.forward);
		RaycastHit hit;

		GameObject hitButton = null;
		PointerEventData data = new PointerEventData (EventSystem.current);

		if (Physics.Raycast (ray, out hit))
		{
			Debug.Log("success 111111111");
			if (hit.transform.gameObject.tag == "Button")
			{
							Debug.Log("success 22222222");
				hitButton = hit.transform.parent.gameObject;
			}
		}

		if (currentButton != hitButton)
		{
			if (currentButton != null)
			{ 
				// unhighlight
				ExecuteEvents.Execute<IPointerExitHandler> (currentButton, data, ExecuteEvents.pointerExitHandler);
			}

			currentButton = hitButton;
			if (currentButton != null)
			{ 
				// highlight
				ExecuteEvents.Execute<IPointerEnterHandler> (currentButton, data, ExecuteEvents.pointerEnterHandler);

				countDown = timeToSelect;
			}
		}
			
		if(currentButton != null)
		{
			countDown -= Time.deltaTime;

			if (clicker.clicked () || countDown < 0.0f)
			{
				ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler); 

				countDown = timeToSelect;
			}
		}
	}
}