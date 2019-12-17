using UnityEngine;

namespace Vuforia
{
	public class CustomTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
	{
		#region VARS (public)
		public GameObject gameObjectWithMovieTexture;
		#endregion

		#region VARS (private)
		private TrackableBehaviour mTrackableBehaviour;
		#endregion
		
		#region METHODS (internal)
		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler (this);
			}
		}
		#endregion
		
		#region METHODS (public)
		public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,
		                                    TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound ();
			}
			else
			{
				OnTrackingLost ();
			}
		}
		#endregion
		
		#region PRIVATE_METHODS
		private void OnTrackingFound()
		{
			// enable rendering
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			
			// enable colliders
			Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			// play movie texture
			((MovieTexture)gameObjectWithMovieTexture.GetComponent<Renderer> ().material.mainTexture).Play ();

			// debug
			Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}
		
		private void OnTrackingLost()
		{
			// disable rendering
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}
			
			// disable colliders
			Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
			
			// stop movie texture
			((MovieTexture)gameObjectWithMovieTexture.GetComponent<Renderer> ().material.mainTexture).Stop ();

			// debug
			Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}
		#endregion
	}
}
