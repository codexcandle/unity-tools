/* 
NOTE:
inspired by:
http://unity.grogansoft.com/fade-your-ui-in-and-out/

USAGE:
1.
// ... ENSURE "CANVAS GROUP" COMPONENT IS ATTACHED TO TARGET "CANVAS"!

2.
StartCoroutine(FadeEffect.FadeCanvas(myCanvas, 1f, 0f, 2f));

3.
IEnumerator FadeThenShowButtons()
{
     // start fading
     yield return StartCoroutine(FadeEffect.FadeCanvas(myCanvas, 1f, 0f, 2f));
     // code here will run once the fading coroutine has completed
     myButton.enabled = true;
}
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebycandle.Util.UI
{
    public class FadeEffect:MonoBehaviour
    {
        public static IEnumerator FadeCanvas(CanvasGroup canvasGroup, 
                                                float startAlpha, 
                                                float endAlpha, 
                                                float duration)
        {
            var startTime = Time.time;
            var endTime = Time.time + duration;
            var elapsedTime = 0f;

            // set start alpha
            canvasGroup.alpha = startAlpha;

            // fade
            while (Time.time <= endTime)
            {
                elapsedTime = Time.time - startTime;
                var percentage = 1 / (duration / elapsedTime);

                // if fading out
                if (startAlpha > endAlpha)
                {
                    canvasGroup.alpha = startAlpha - percentage;
                }
                // if fading in
                else
                {
                    canvasGroup.alpha = startAlpha + percentage;
                }

                // wait for next frame before continuing loop
                yield return new WaitForEndOfFrame();
            }

            // force alpha to end (to mitigate any rounding errors)
            canvasGroup.alpha = endAlpha;
        }

        public static IEnumerator FadeTexture(GameObject safeFrame /* Material material*/, 
                                                float startAlpha, 
                                                float endAlpha, 
                                                float duration)
        {
            var startTime = Time.time;
            var endTime = Time.time + duration;
            var elapsedTime = 0f;

            // set start alpha
            Material material = safeFrame.GetComponent<Renderer>().material;
            Color c = material.color;
            c.a = startAlpha;

            // fade
            while (Time.time <= endTime)
            {
                elapsedTime = Time.time - startTime;
                var percentage = 1 / (duration / elapsedTime);

                // if fading out
                if (startAlpha > endAlpha)
                {
                    c.a = startAlpha - percentage;
                }
                // if fading in
                else
                {
                    c.a = startAlpha + percentage;
                }

                material.color = c;

                // wait for next frame before continuing loop
                yield return new WaitForEndOfFrame();
            }

            // force alpha to end (to mitigate any rounding errors)
            c.a = endAlpha;

            material.color = c;
        }
    }
}