// SOURCE: 
// https://library.vuforia.com/articles/Solution/Unity-Dynamically-attach-a-3D-model-to-an-Image-Target
// PUPROSE:
// VuforiaAR; augment an image target with a custom 3D model that is instantiated at run time, upon target detection, using the Vuforia Unity extension and the Prefab instantiation technique.

using UnityEngine;
using System.Collections;
public class MyPrefabInstantiator : MonoBehaviour /*, ITrackableEventHandler */ {

  /* TODO - add below AFTER VUFORIA package inacluded in project! */
  /*
  private TrackableBehaviour mTrackableBehaviour;
  public Transform myModelPrefab;
  // Use this for initialization
  void Start ()
  {
    mTrackableBehaviour = GetComponent<TrackableBehaviour>();
    if (mTrackableBehaviour) {
      mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
  }
  // Update is called once per frame
  void Update ()
  {
  }
  public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
  { 
    if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
    {
      OnTrackingFound();
    }
  } 
  private void OnTrackingFound()
  {
    if (myModelPrefab != null)
    {
      Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
      myModelTrf.parent = mTrackableBehaviour.transform;
      myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
      myModelTrf.localRotation = Quaternion.identity;
      myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
      myModelTrf.gameObject.active = true;
    }
  }
  */
}