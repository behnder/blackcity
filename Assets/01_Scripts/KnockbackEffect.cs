using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] float knockbackForce = 5.0f;
    [SerializeField] float knockbackDuration = 0f;
    [SerializeField] float knockbackTotalTime = 0.2f;
    [SerializeField] string collisionKnockbackTag;
    [SerializeField] bool knockBackFromRight;

    private Rigidbody2D rb;
    private float knockbackStartTime;
    private bool canKnockback;
    //----------------------------------------
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (knockbackDuration <= 0)
        {
            playerMovement.canMoveItSelf = true;
        }
        else
        {
            if (knockBackFromRight == true)
            {
                rb.velocity = new Vector2(knockbackForce, 5f);
            }
            if (knockBackFromRight == false)
            {
                rb.velocity = new Vector2(-knockbackForce, 5f);
            }
            knockbackDuration -= Time.deltaTime;
            playerMovement.canMoveItSelf = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            knockbackDuration = knockbackTotalTime; //set the timer for the collision

            if (collision.transform.position.x <= transform.position.x) //select if it's from the right or left side
            {
                knockBackFromRight = true;
            }
            else
            {
                knockBackFromRight = false;
            }
        }
    }
}