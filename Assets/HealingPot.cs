using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerHealth>().Health = 500;
        Destroy(gameObject);
    }
}
