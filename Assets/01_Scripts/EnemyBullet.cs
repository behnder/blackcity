using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("DisableBullet", 0, 3f);

        //Physics.IgnoreCollision(9,12)
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("CameraZoomArea") && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Health -= 100;
            gameObject.SetActive(false);
        }
        
        //if (collision.gameObject.CompareTag("Player") )
        //{

        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.gameObject.CompareTag("CameraZoomArea"))
    //    {

    //        gameObject.SetActive(false);
    //    }
    //}

    void DisableBullet()
    {
        gameObject.SetActive(false);
    }

}
