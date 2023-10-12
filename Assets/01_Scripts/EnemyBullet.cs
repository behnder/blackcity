using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void Start()
    {
       // InvokeRepeating("DisableBullet", 0, 3f);
    }

    private void OnEnable()
    {
        Invoke("DisableBullet", 6f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("CameraZoomArea") && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Health -= 100;
            DisableBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DisableBullet();
        }
    }


    void DisableBullet()
    {
        gameObject.SetActive(false);
    }

}
