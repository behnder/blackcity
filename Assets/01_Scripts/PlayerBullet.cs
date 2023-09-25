using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //private void Start()
    //{
    //    InvokeRepeating("DisableBullet", 0, 1f);
    //}

    private void OnEnable()
    {
        Invoke("DisableBullet", 3f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DisableBullet();
        if (collision.gameObject.CompareTag("Boss"))
        {

            collision.gameObject.GetComponent<EnemyMelee>().Health -= 100;
            collision.gameObject.GetComponent<EnemyMelee>().CheckHealth();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Boss"))
    //    {

    //        collision.gameObject.GetComponent<EnemyMelee>().Health -= 100;
    //            collision.gameObject.GetComponent<EnemyMelee>().CheckHealth();

    //        DisableBullet();

    //    }

    //}
    void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
