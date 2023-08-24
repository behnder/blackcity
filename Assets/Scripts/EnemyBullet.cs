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
        print("ON COLLISION BULLET");
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ON TRIGGER BULLET");

        gameObject.SetActive(false);
    }

    void DisableBullet()
    {
        gameObject.SetActive(false);
    }

}
