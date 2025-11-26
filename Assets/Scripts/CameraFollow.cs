using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Will be assigned by GameManager
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 5, -7); 

    void LateUpdate()
    {
        // If Doofus hasn't spawned yet, don't move
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}