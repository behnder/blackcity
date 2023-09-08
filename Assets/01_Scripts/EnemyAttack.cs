using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] string tagToCollide;
 

    void OnCollisionEnter2D(Collision2D collision)
    {
        #region pushback effect
        Vector2 hitDirection = collision.transform.position - transform.position;
        EnemyPushBackEffect pushbackEffect = collision.gameObject.GetComponent<EnemyPushBackEffect>();
        if (pushbackEffect != null)
        {
            pushbackEffect.Hit(hitDirection.normalized); // Pass normalized hit direction
        }
        #endregion

        if (collision.gameObject.CompareTag(tagToCollide))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Health -= 50;
            if (collision.gameObject.GetComponent<PlayerHealth>().Health <= 0)
            {
                collision.gameObject.GetComponent<PlayerMovement>().Speed = 0;
                collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
