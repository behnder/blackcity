using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPot : MonoBehaviour
{
    [SerializeField] AudioSource potionCollectedSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        collision.GetComponent<PlayerHealth>().Health = 600;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        potionCollectedSFX.Play();
        Invoke("DestroyItSelf", 0.3f);

        }
    }

    private void DestroyItSelf()
    {

        Destroy(gameObject);
    }
}
