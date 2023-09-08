using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] string tagToCollide;
    private int damage = 3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCollide))
        {
            Vector2 hitDirection = collision.transform.position - transform.position;

            // Call the Hit method of the enemy's EnemyController
            EnemyPushBackEffect pushbackEffect = collision.GetComponent<EnemyPushBackEffect>();
            if (pushbackEffect != null)
            {
                pushbackEffect.Hit(hitDirection.normalized); // Pass normalized hit direction
            }
            if (collision.GetComponent<IHealth>() != null)
            {
                collision.GetComponent<IHealth>().Health -= 100;
                collision.GetComponent<IHealth>().CheckHealth();
   
            }


        }
    }

}

