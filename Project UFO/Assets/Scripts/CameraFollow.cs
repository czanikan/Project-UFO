using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPoint = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPoint;

        transform.LookAt(target);
    }
}
