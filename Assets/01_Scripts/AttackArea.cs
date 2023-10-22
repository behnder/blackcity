using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] string tagToCollide;
    [SerializeField] AudioSource hitOnEnemySFX;
    private int damage = 3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCollide))
        {
            Vector2 hitDirection = collision.transform.position - transform.position;

            // Call the Hit method of the enemy's EnemyController
            #region pushback effect
            EnemyPushBackEffect pushbackEffect = collision.GetComponent<EnemyPushBackEffect>();
            if (pushbackEffect != null)
            {
                pushbackEffect.Hit(hitDirection.normalized); // Pass normalized hit direction
            }
            #endregion
            if (collision.GetComponent<IHealth>() != null)
            {
                hitOnEnemySFX.Play();
                collision.GetComponent<IHealth>().Health -= 100;
                collision.GetComponent<IHealth>().CheckHealth();
   
            }


        }
    }

}

