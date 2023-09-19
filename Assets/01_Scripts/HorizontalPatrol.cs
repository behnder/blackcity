using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPatrol : MonoBehaviour , IHealth
{

    public float moveSpeed = 2f; // Speed at which the enemy moves horizontally.
    public float patrolDistance = 4f; // Distance the enemy will patrol before turning around.

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private Vector2 patrolEndPosition;
    private int moveDirection = 1; // 1 for right, -1 for left.
    public float health;



    public float Health { get => health; set => health = value; }

    void Start()
    {

        Health = health;
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        patrolEndPosition = initialPosition + new Vector2(patrolDistance, 0);
    }

    void Update()
    {
        if (transform.position.x >= patrolEndPosition.x || transform.position.x <= initialPosition.x)
        {
            // Change direction when reaching either end.
            moveDirection *= -1;
        }
    }

    void FixedUpdate()
    {
        // Move the enemy horizontally.
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }

    public void CheckHealth()
    {
        if (Health <= 0)
        {
            GetComponent<Animator>().Play("Enemy_Dying");
            
            Invoke("DestroyItself", 0.5f);
        }
    }
    void DestroyItself()
    {
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        print("im here");
    //        //Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider2D>(), GetComponent<Collider2D>());
    //    }
    //}
}
