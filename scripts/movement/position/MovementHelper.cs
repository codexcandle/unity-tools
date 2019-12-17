using System.Collections;
using UnityEngine;

namespace Codebycandle.Util.Tform
{
    // SOURCE:      Found while googling; forget site!
    // FUNCTION:    Move Stuff!
    // EX:          StartCoroutine (MoveOverSeconds (gameObject, new Vector3 (0.0f, 10f, 0f), 5f));
    public class MovementHelper:MonoBehaviour
    {
        public IEnumerator MoveBySpeed(GameObject target, Vector3 endPos, float speed)
        {
            // speed should be 1 unit per second
            while (target.transform.position != endPos)
            {
                target.transform.position = Vector3.MoveTowards(target.transform.position,
                    endPos,
                    speed * Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }
        }

        public IEnumerator MoveByTime(GameObject target, Vector3 endPos, float seconds)
        {
            float elapsedTime = 0;
            Vector3 startingPos = target.transform.position;
            while (elapsedTime < seconds)
            {
                target.transform.position = Vector3.Lerp(startingPos,
                    endPos,
                    (elapsedTime / seconds));

                elapsedTime += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            target.transform.position = endPos;
        }

        public void MoveRigidBody(Rigidbody rb, Vector3 force, float speed = 1.0F)
        {
            // TODO - confirm if should add Time.deltaTime?
            rb.AddForce(force * speed /* * Time.deltaTime*/);
        }
    }
}