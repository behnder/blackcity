using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPushBackEffect : MonoBehaviour
{
    public float pushbackDistance = 0.5f; // Distance to push the enemy back
    public float pushbackForce = 5f;      // Speed at which to push back

    public void Hit(Vector2 hitDirection)
    {
        // Calculate the pushback direction
        Vector2 pushbackDirection = hitDirection.normalized;

        // Apply the pushback force to the enemy's Rigidbody2D
        GetComponent<Rigidbody2D>().AddForce(pushbackDirection * pushbackForce, ForceMode2D.Impulse);
    }

  
}
