using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] string tagToCollide;
    [SerializeField] AudioSource attackSfx;
    [SerializeField] AudioSource dieSfx;
 

    void OnCollisionEnter2D(Collision2D collision)
    {


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
    void PlayAttackSFX()
    {
        attackSfx.Play();
    }

    void PlayDieSFX()
    {
        dieSfx.Play();
    }
}
