using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;        // Car ka Transform
    public Vector3 offset;       // Camera ka distance
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 desiredPosition = car.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
        transform.position = smoothPosition;

        transform.LookAt(car);
    }
}
