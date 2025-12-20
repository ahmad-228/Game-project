using UnityEngine;

public class CarMoveRB : MonoBehaviour
{
    public float speed = 20f;       // realistic speed
    public float turnSpeed = 100f;  // rotation speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody missing! Please add a Rigidbody component.");
        }
        else
        {
            rb.linearDamping = 1f;               // linear damping
            rb.angularDamping = 2f;        // angular damping
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");   // W/S
        float turn = Input.GetAxis("Horizontal"); // A/D

        // Move forward/backward
        Vector3 forwardMove = transform.forward * move * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Rotate around Y-axis
        float turnAmount = turn * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

}
