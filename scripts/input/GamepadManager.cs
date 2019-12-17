// CLASS NAME:	GAMEPAD MANAGER
// PURPOSE:		Gamepad "Input Manager" class (modelled from "Gamesir G3s")
// O-AUTHOR:	NONE
namespace Codebycandle.Input
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class GamepadManager:MonoBehaviour
	{
		// TODO - implement delegate (action) ///////////////////
		public Text tf;
		private void HandleInputEvent(string txt)
		{
			tf.text = txt;
		}
		// //////////////////////////////////////////////////////	

		private const string AXIS_H1	= "Horizontal1";
		private const string AXIS_V1 	= "Vertical1";
		private const string AXIS_H2	= "Horizontal2";
		private const string AXIS_V2 	= "Vertical2";	

		private bool gamepadExists;
		private float joystickH;
		private float joystickV;

		private enum BUTTON
		{
			AButton,
			BButton,
			XButton,
			YButton,
			// TODO - get btns below working!
			L1,
			L2,
			R1,
			R2,
			Select,
			Start,
			Turbo,
			Clear
		}

		void Awake()
		{
			gamepadExists = IsGamepads();

			HandleInputEvent("Gamepads: " + gamepadExists);
		}

		void Update()
		{
			HandleJoysticks();

			HandleButtons();
		}

		private bool IsGamepads(bool displayNames = false)
		{
			string[] names = Input.GetJoystickNames();

			if(displayNames)
			{
				for(int i = 0; i < names.Length; i++)
				{
					HandleInputEvent("Connected Joystick: " + (i + 1) + " = " + names[i]);
				}
			}

			return (names.Length > 0);
		}

		private bool IsJoyStickActive(string axisNameH, string axisNameV)
		{
			float hor = GetAxisVal(axisNameH);
			float ver = Input.GetAxis(axisNameV);
			if(hor != 0 || ver != 0)
			{
				// Debug.Log(" **** hor1: " + hor + " ***** ver1: " + ver);

				return true;
			}

			return false;
		}

		private bool IsButtonActive(BUTTON btn)
		{
			return Input.GetButtonDown(btn.ToString());
		}

		private void HandleJoysticks()
		{
			bool joystick1 = IsJoyStickActive(AXIS_H1, AXIS_V1);
			bool joystick2 = IsJoyStickActive(AXIS_H2, AXIS_V2);

			if(joystick1 || joystick2)
			{
				string msg = " ************ joystick change:";

				if(joystick1)
				{
					msg += "joystick1 " + " h: " + GetAxisVal(AXIS_H1) + " v: " + GetAxisVal(AXIS_V1);
				}

				if(joystick2)
				{
					msg += "joystick2 " + " h: " + GetAxisVal(AXIS_H2) + " v: " + GetAxisVal(AXIS_V2);
				}

				HandleInputEvent(msg);
			}
		}

		private void HandleButtons()
		{
			// TODO - possibly implement "fire frequency threshold" limit

			BUTTON[] btns = (BUTTON[])System.Enum.GetValues(typeof(BUTTON));

			foreach(BUTTON btn in btns)
			{
				bool btnActive = IsButtonActive(btn);
				if(btnActive)
				{
					HandleInputEvent("button (" + btn.ToString() + ") ACTIVE");
				}
			}
		}

		private float GetAxisVal(string axisName)
		{
			// TODO - implemenet cross-platform? (can't get to work!)
			// CrossPlatformInputManager.GetAxis("Horizontal")

			return UnityEngine.Input.GetAxis(axisName);
		}
	}
}