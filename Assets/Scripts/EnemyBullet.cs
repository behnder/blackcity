using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("DisableBullet", 0, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("CameraZoomArea"))
        {

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("CameraZoomArea"))
        {

            gameObject.SetActive(false);
        }
    }

    void DisableBullet()
    {
        gameObject.SetActive(false);
    }

}
