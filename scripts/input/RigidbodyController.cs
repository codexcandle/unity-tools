using UnityEngine;
using System;

namespace Codebycandle.Util.Input
{
    /* 
     * SOURCE:
     *  inspired by: 
     *  https://unity3d.com/learn/tutorials/projects/-
     *  roll-ball-tutorial/moving-player?playlist=17141
     * 
     * PURPOSE:
     *  wrapper for rigidbody-based object movement
     */
    public class RigidbodyController:MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody rb;

        public bool listenToAxes { get; set; }

        public void MoveLeft()
        {
            Move(new Vector3(-1, 0, 0), speed);
        }

        public void MoveRight()
        {
            Move(new Vector3(1, 0, 0), speed);
        }

        public void MoveForward()
        {
            Move(new Vector3(0, 0, 1), speed);
        }

        public void MoveBackward()
        {
            Move(new Vector3(0, 0, -1), speed);
        }
   
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if(listenToAxes)
            {
                float moveHorizontal = UnityEngine.Input.GetAxis("Horizontal");
                float moveVertical = UnityEngine.Input.GetAxis("Vertical");

                Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);

                /* TODO - confirm if need 
                 * ".deltaTime" here or not 
                 * for "fixed" update? */
                Move(force, speed * Time.deltaTime);
            }
        }

        private void Move(Vector3 force, float velocity)
        {
            rb.AddForce(force * velocity);
        }
    }
}