using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;              // Reference to the character's transform
    [SerializeField] float smoothSpeed = 0.5f;      // Smoothing factor for camera movement
    [SerializeField] Vector3 offset;                // Offset between the character and the camera
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
