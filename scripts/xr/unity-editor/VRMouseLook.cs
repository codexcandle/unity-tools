/**********************************************************
SOURCE:  	packt pub ebook (unity vr projects)
NAME:		VRMouseLook
FUNCTION:	Mock VR HMD movement in Unity editor.  
            - speeds up dev work for VR, since you don't have 
            to wear the GearVR each time to test.  Yay!
**********************************************************/
using UnityEngine;

public class VRMouseLook:MonoBehaviour
{
    // #if UNITY_EDITOR

    public bool enableYaw = true;
    public bool autoRecenterPitch = true;
    public bool autoRecenteRoll = true;

    public KeyCode HorizontalAndVerticalKey;
    public KeyCode RollKey = KeyCode.LeftControl;

    Transform vrCameraTransform;
    Transform rotationTransform;
    Transform forwardTransform;

    private float mouseX = 0;
    private float mouseY = 0;
    private float mouseZ = 0;

    void Awake()
    {
        // get vr cam so can align our forward with it
        Camera vrCamera = gameObject.GetComponentInChildren<Camera>();
        vrCameraTransform = vrCamera.transform;

        // create hierarchy to enable us to additionally rotate the vr cam
        rotationTransform = new GameObject("VR Mouse Look (Rotation)").GetComponent<Transform>();
        forwardTransform = new GameObject("VR Mouse Look (Forward)").GetComponent<Transform>();
        rotationTransform.SetParent(transform.parent, false);
        forwardTransform.SetParent(rotationTransform, false);
        transform.SetParent(forwardTransform, false);
    }

    void Update()
    {
        bool rolled = false;
        bool pitched = false;
        if(Input.GetKey(HorizontalAndVerticalKey))
        {
            pitched = true;
            if(enableYaw)
            {
                mouseX += Input.GetAxis("Mouse X") * 5;
                if (mouseX <= -180)
                {
                    mouseX += 360;
                }
                else if(mouseX > 180)
                {
                    mouseX -= 360;
                }
            }
            mouseY -= Input.GetAxis("Mouse Y") * 2.4f;
            mouseY = Mathf.Clamp(mouseY, -85, 85);
        }
        else if(Input.GetKey(RollKey))
        {
            rolled = true;
            mouseZ += Input.GetAxis("Mouse X") * 5;
            mouseZ = Mathf.Clamp(mouseZ, -85, 85);
        }

        if(!rolled && autoRecenteRoll)
        {
            // people don't usually leave their heads tilted to one side for long.
            mouseZ = Mathf.Lerp(mouseZ, 0, Time.deltaTime / (Time.deltaTime + 0.1f));
        }
        if(!pitched && autoRecenterPitch)
        {
            // People don't usually leave their heads tilted to one side for long.
            mouseY = Mathf.Lerp(mouseY, 0, Time.deltaTime / (Time.deltaTime + 0.1f));
        }

        forwardTransform.localRotation = Quaternion.Inverse(Quaternion.Euler(0.0f, vrCameraTransform.localRotation.eulerAngles.y, 0.0f));
        rotationTransform.localRotation = Quaternion.Euler(0, vrCameraTransform.localRotation.eulerAngles.y, 0.0f) * Quaternion.Euler(mouseY, mouseX, mouseZ);
    }

    // #endif
}
