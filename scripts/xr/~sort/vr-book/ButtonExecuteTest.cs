using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonExecuteTest:MonoBehaviour
{
	private GameObject startButton, stopButton;

	private bool on = false;
	private float timer = 5.0f;

	void Start()
	{
		startButton = GameObject.Find("StartButton");
		stopButton = GameObject.Find("StopButton");
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if(timer < 0.0f)
		{
			on = !on;

			timer = 5.0f;

			// via "on" flag, forces "click" event on start || stop button
			PointerEventData data = new PointerEventData(EventSystem.current);

			ExecuteEvents.Execute<IPointerClickHandler>(on ? startButton : stopButton, data, ExecuteEvents.pointerClickHandler);
		}
	}
}