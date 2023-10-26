using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource shootSFX;
    CircleCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        Invoke("DisableBullet", 3f);
        shootSFX.Play();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.Play("Antiboss_Bullet_Destroyed");
        Invoke("DisableBullet",0.3f);
        if (collision.gameObject.CompareTag("Boss"))
        {

            collision.gameObject.GetComponent<EnemyMelee>().Health -= 100;
            collision.gameObject.GetComponent<EnemyMelee>().CheckHealth();
        }
        collider.enabled = false;
    }


    void DisableBullet()
    {
        gameObject.SetActive(false);
        collider.enabled = true;

    }
}
