using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    public float knockbackForce = 5.0f;
    public float knockbackDuration = 0.2f;

    private Rigidbody2D rb;
    private float knockbackStartTime;
    private bool canKnockback;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canKnockback = true;
            // Calculate the knockback direction away from the enemy.
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            // Apply the knockback force.
            rb.velocity = knockbackDirection * knockbackForce;

            // Record the time when knockback started.
            knockbackStartTime = Time.time;
        }
    }

    private void Update()
    {
        if (canKnockback)
        {
            if (Time.time - knockbackStartTime > knockbackDuration)
            {
                // Disable the knockback effect by resetting the velocity.
                rb.velocity = Vector2.zero;

            }
            canKnockback = false;
        }
        // Check if the knockback duration has passed.
    }
}
