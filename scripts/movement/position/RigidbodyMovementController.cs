// SOURCE: https://unity3d.com/learn/tutorials/projects/roll-ball-tutorial/moving-player?playlist=17141
// PURPOSE:  add "player-controlled" object movement
using UnityEngine;

public class RigidbodyInputMovementController:MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        // TODO - confirm is need "* Time.deltaTime" here or not for "fixed" update?
        rb.AddForce (movement * speed);
    }
}