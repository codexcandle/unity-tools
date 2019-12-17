using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebycandle.Util.Screen
{
    public class ScreenshotHelper:MonoBehaviour
    {
        private Texture2D PlaneTex;

        #region UTIL-PRIVATE
        private IEnumerator CaptureScreenshot()
        {
            // need to wait til' end of frame!
            yield return new WaitForEndOfFrame();

            /*
            PlaneTex = ScreenCapture.CaptureScreenshotAsTexture();
            yield return new WaitForEndOfFrame();

            GameObject newPlane = Instantiate(plane, spawnPoint.position, Camera.main.transform.rotation);
            newPlane.GetComponent<MeshRenderer>().material.mainTexture = PlaneTex;
            PlaneTex.Apply();
            */
        }
        #endregion

        #region UTIL-PUBLIC
        public void CaptureShot()
        {
            /// StartCoroutine(CaptureScreenshot);
        }
        #endregion
    }
}