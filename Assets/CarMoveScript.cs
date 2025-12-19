using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;       // aage / peeche
    public float turnSpeed = 50f;   // left / right

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Forward / Backward
        float move = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + transform.forward * move);

        // Left / Right
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, turn, 0);
    }
}
