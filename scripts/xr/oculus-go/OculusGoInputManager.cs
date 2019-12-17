using UnityEngine;
using Codebycandle.Util.Arch;

namespace Codebycandle.Util.Input
{
    // CLASS NAME:	OCULUS-GO INPUT MANAGER
    // PURPOSE:		listens for "Oculus Go" device input events
    // AUTHOR:	    CXC (w/ inpsiration from unknown(?) website forum page)
    public class OculusGoInputManager:GenericSingletonClass<OculusGoInputManager>
    {
        #region PROPERTIES
        public enum GestureMove
        {
            NONE,
            click,
            swipeLeft,
            swipeRight,
            swipeUp,
            swipeDown
        };

        public delegate void InputEvent(GestureMove move);
        public static event InputEvent OnInputEvent;

        private float GetAxisX;
        private float GetAxisY;
        private Vector3 mousePosition;
        private bool MovingDirectionLockedToX;
        private bool MovingDirectionLockedToY;
        private bool mouseDown;

        // **************************
        private Vector3 startSwipePos;
        private Vector3 endSwipePos;
        private bool moveUsed;
        GestureMove curMove;
        #endregion

        #region METHODS (internal)
        void Update()
        {
            bool activeInput = false;

            if (UnityEngine.Input.GetMouseButtonDown(0) && mouseDown == false)
            {
                // Initial Press
                GetAxisX = GetAxisY = 0f;
                MovingDirectionLockedToX = false;
                MovingDirectionLockedToY = false;
                mousePosition = UnityEngine.Input.mousePosition;
                mouseDown = true;

                activeInput = true;

                // **************************
                endSwipePos = Vector3.zero;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0) && mouseDown)
            {
                // Released
                GetAxisX = GetAxisY = 0f;
                MovingDirectionLockedToX = false;
                MovingDirectionLockedToY = false;
                mouseDown = false;

                activeInput = true;

                // **************************
                endSwipePos = UnityEngine.Input.mousePosition;
                startSwipePos = Vector3.zero;
                moveUsed = false;
            }
            else if (mouseDown)
            {
                // **************************
                if (startSwipePos == Vector3.zero)
                {
                    startSwipePos = UnityEngine.Input.mousePosition;
                    endSwipePos = Vector3.zero;
                }

                endSwipePos = UnityEngine.Input.mousePosition;
                // **************************

                // Detect Axis Movement
                Vector3 newMousePosition = UnityEngine.Input.mousePosition;
                Vector3 deltaMousePosition = mousePosition - newMousePosition;

                float x = deltaMousePosition.x > 5 ? 1f : (deltaMousePosition.x < -5 ? -1f : 0);
                float y = deltaMousePosition.y > 5 ? 1f : (deltaMousePosition.y < -5 ? -1f : 0);

                // which direction do we care about ?
                if (MovingDirectionLockedToX == false && MovingDirectionLockedToY == false && (Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0))
                {
                    if (Mathf.Abs(deltaMousePosition.x) > Mathf.Abs(deltaMousePosition.y))
                    {
                        MovingDirectionLockedToX = true;

                        activeInput = true;
                    }
                    else
                    {
                        MovingDirectionLockedToY = true;

                        activeInput = true;
                    }
                }

                if (MovingDirectionLockedToX && Mathf.Abs(x) > 0)
                {
                    GetAxisX = x;
                }

                if (MovingDirectionLockedToY && Mathf.Abs(y) > 0)
                {
                    GetAxisY = y;
                }

                mousePosition = newMousePosition;
            }

            // ////////////////////////////////////////////////////////////////////////////
            float swipePixelThreshold = 60F;

            GestureMove move = GestureMove.NONE;

            if(startSwipePos != Vector3.zero)
            {
                if (mouseDown)
                {
                    if (MovingDirectionLockedToX)
                    {
                        if (endSwipePos.x > (startSwipePos.x + swipePixelThreshold))
                        {
                            move = GestureMove.swipeLeft;
                        }
                        else if (endSwipePos.x < (startSwipePos.x - swipePixelThreshold))
                        {
                            move = GestureMove.swipeRight;
                        }
                    }
                    else if (MovingDirectionLockedToY)
                    {
                        if (endSwipePos.y > (startSwipePos.y + swipePixelThreshold))
                        {
                            move = GestureMove.swipeUp;
                        }
                        else if (endSwipePos.y < (startSwipePos.y - swipePixelThreshold))
                        {
                            move = GestureMove.swipeDown;
                        }
                    }
                    else
                    {
                        move = GestureMove.click;
                    }
                }
            }
            // ////////////////////////////////////////////////////////////////////////////

            // notify
            if (move != GestureMove.NONE) HandleInputEvent(move);
        }
        #endregion

        #region METHODS (private)
        private void HandleInputEvent(GestureMove move)
        {
            if(!moveUsed)
            {
                moveUsed = true;

                if(OnInputEvent != null)
                {
                    OnInputEvent(move);
                }

                curMove = move;
            }
        }
        #endregion
    }
}