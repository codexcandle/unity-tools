using System.Collections;
using UnityEngine;

namespace Codebycandle.Util.Ani
{
    public class ScaleByCurve:MonoBehaviour
    {
        [Header("Anim-Curve")]
        [SerializeField] AnimationCurve curve;
        [SerializeField] float time = 10f;
        // [SerializeField] Vector3 finalPos;
        private Vector3 finalScale;

        // private Vector3 initPos;
        private Vector3 initScale;

        private float graphValue;

        private Material mat;

        private void Awake()
        {
            // initPos = transform.localPosition;
            initScale = Vector3.zero;   //  transform.localScale;
            finalScale = Vector3.one;

            // curve.postWrapMode = WrapMode.Loop;

            /*
            mat = transform.GetComponent<Renderer>().material;
            float curAlpha = mat.color.a;
            mat.color = new Color32(0, 0, 0, 0);
            */
        }

        private void Start()
        {
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            float i = 0;
            float rate = 1 / time;
            while (i < 1)
            {
                i += rate * Time.deltaTime;
                // transform.localPosition = Vector3.Lerp(initPos, finalPos, curve.Evaluate(i));

                // update scale
                Vector3 newScale = Vector3.Lerp(initScale, finalScale, curve.Evaluate(i));
                transform.localScale = newScale;

                /*
                // update pos
                Color32 c = mat.color;
                Color newColor = new Color();
                newColor.r = c.r;
                newColor.g = c.g;
                newColor.b = c.b;
                newColor.a = newScale.x;

                mat.color = newColor;
                */

                yield return 0;
            }
        }
    }
}