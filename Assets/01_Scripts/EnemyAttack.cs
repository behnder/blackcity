using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] string tagToCollide;
    [SerializeField] AudioSource attackSfx;
    [SerializeField] AudioSource dieSfx;
    private GameObject player;
    private float playerSpeed;

    private void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag(tagToCollide))
        {
            player = collision.gameObject;
            playerSpeed = player.GetComponent<PlayerMovement>().Speed;
            player.GetComponent<PlayerHealth>().Health -= 50;
            if (player.GetComponent<PlayerHealth>().Health <= 0)
            {
                player.GetComponent<PlayerMovement>().Speed = 0;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<CapsuleCollider2D>().enabled = false;
                player.GetComponent<SpriteRenderer>().enabled = false;

                if(player.GetComponent<PlayerHealth>().lives > 0)
                {
                    Invoke("EnablePlayerAgain", 1f);
                    //StartCoroutine("EnablePlayerAgain");
                }
            }
        }
    }
    //IEnumerator EnablePlayerAgain()
    //{
               
    //    yield return new WaitForSeconds(3);
    //    player.GetComponent<PlayerMovement>().Speed = playerSpeed;
    //    player.GetComponent<PlayerMovement>().enabled = true;
    //    player.GetComponent<SpriteRenderer>().enabled = true;
    //}

    private void EnablePlayerAgain()
    {       
        player.GetComponent<PlayerMovement>().Speed = 6;
        player.GetComponent<CapsuleCollider2D>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
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
