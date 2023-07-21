using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float raycastDistance;
    [SerializeField] LayerMask platformLayer;
    [SerializeField] GameObject weapon;


    private Rigidbody2D rigidbody;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isTouchingWall;

    [SerializeField] float move;

    private Animator animator;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HorizontalMovement();
        Jump();

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }



    private void HorizontalMovement()
    {
        move = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(move * speed, rigidbody.velocity.y);
    }

    private void ActivateWeapon()
    {
        weapon.SetActive(true);
    }
    private void DeactivateWeapon()
    {
        weapon.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

    }

    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAttacking", false);
    }
}
