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
            Destroy(collision.gameObject);
            print("IM IN COLLISION");
        }
    }
  
}

