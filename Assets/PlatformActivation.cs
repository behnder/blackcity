using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivation : MonoBehaviour
{
    [SerializeField] string tagToCollide;

    public float rotationSpeed = 90f;

    private Quaternion targetRotation;
    private Quaternion initialRotation;
    private float elapsedTime;
    private bool platformRotation = false;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0f, 0f, -90f); // Rotate 90 degrees clockwise
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (platformRotation)
        {
            if (elapsedTime < 1f)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime);

                // Use Quaternion.Lerp to smoothly interpolate the rotation
                transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            }

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("COLLIDING");
        if (collision.gameObject.CompareTag(tagToCollide))
        {
            platformRotation = true;
        }
    }
}
