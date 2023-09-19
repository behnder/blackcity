using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVerticalMove : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Speed of the platform's movement.
    public float moveDistance = 2.0f; // Distance the platform moves up and down.

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingUp = true;
    public GameObject waitForActivation;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.up * moveDistance;
    }
    private void FixedUpdate()
    {
        if (waitForActivation == null)
        {
            // Calculate the new position for the platform and go up or down depending if the route if finished
            Vector3 targetPos = movingUp ? endPos : startPos; 
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // Check if the platform has reached its target position.
            if (transform.position == targetPos)
            {
                movingUp = !movingUp; // Change direction.
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //With this the player will get "stick" to the platform
            collision.transform.SetParent(transform);
        }
    }
    // OnCollisionExit2D is used to release the player from the platform.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
