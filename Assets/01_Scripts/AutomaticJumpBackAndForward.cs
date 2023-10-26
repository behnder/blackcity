using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticJumpBackAndForward : MonoBehaviour
{


    public float jumpDistance;  // Distance to jump forward
    public float jumpForce;    // Jump force
    public float jumpInterval; // Time interval between jumps

    private Vector3 originalPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;

        // Start the jumping coroutine
        StartCoroutine(JumpForwardAndBack());
    }

    private IEnumerator JumpForwardAndBack()
    {
        while (true)
        {
            // Jump forward
            rb.velocity = new Vector2(jumpDistance, jumpForce);

            // Wait for a moment
            yield return new WaitForSeconds(jumpInterval*2);

            // Jump backward
            rb.velocity = new Vector2(-jumpDistance, jumpForce);

            // Wait for a moment
            yield return new WaitForSeconds(jumpInterval);

            // Return to the original position
            //transform.position = originalPosition;

            // Wait for a moment before starting the loop again
            yield return new WaitForSeconds(jumpInterval );
        }
    }

}
