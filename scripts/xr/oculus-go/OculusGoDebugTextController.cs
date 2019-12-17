using UnityEngine;
using Codebycandle.Util.Arch;
using Codebycandle.Util.UI;

namespace Codebycandle.Util.Input
{
    public class OculusGoDebugTextController:GenericSingletonClass<OculusGoDebugTextController>
    {
        [SerializeField] private TextController tc;

        void OnEnable()
        {
            OculusGoInputManager.OnInputEvent += HandleInputEvent;
        }

        void OnDisable()
        {
            OculusGoInputManager.OnInputEvent -= HandleInputEvent;
        }

        void Start()
        {
            tc.Reset();
        }

        private void HandleInputEvent(OculusGoInputManager.GestureMove move)
        {
            // set text
            string txt = "<color=black>" + move.ToString() + "</color>";
            tc.AddText(txt);

            return;

            /*
            // move cam
            switch (move)
            {
                case OculusGoInputManager.GestureMove.click:
                    crc.MoveForward();
                    break;
                case OculusGoInputManager.GestureMove.swipeLeft:
                    crc.MoveLeft();
                    break;
                case OculusGoInputManager.GestureMove.swipeRight:
                    crc.MoveRight();
                    break;
                case OculusGoInputManager.GestureMove.swipeUp:
                    crc.MoveForward();
                    break;
                case OculusGoInputManager.GestureMove.swipeDown:
                    crc.MoveBackward();
                    break;
                default:
                    Debug.Log("test: " + move.ToString());
                    break;
            }
            */
        }
    }
}