using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Will be assigned automatically by GameManager
    public float smoothSpeed = 0.125f;
    
    // "Even Further Away" Third Person View
    public Vector3 offset = new Vector3(0, 10, -15); 

    void Start()
    {
        // Force these values when the game starts
        offset = new Vector3(0, 10, -15);
    }

    void LateUpdate()
    {
        // If Doofus hasn't spawned yet, do nothing
        if (target == null) return;

        // Calculate where the camera WANTS to be
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly slide from current position to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Apply position
        transform.position = smoothedPosition;
        
        // Make camera look at player
        transform.LookAt(target);
    }
}