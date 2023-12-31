using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] GroundChecker groundChecker;

    public Rigidbody2D rb;
    [SerializeField] private bool isJumping;
    [SerializeField] float move;
    public bool canMoveItSelf = true;

    public float Move { get => move; set => move = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {

            if (canMoveItSelf) // this will be able from knockback script(or not)
            {
                HorizontalMovement();
                Jump();
            }
        }
    }

    private void Jump()
    {
        if (groundChecker.groundChecker)
        {
            isJumping = false;
        }
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            groundChecker.groundChecker = false;
        }
    }
    private void HorizontalMovement()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Move * Speed, rb.velocity.y);
    }
}
