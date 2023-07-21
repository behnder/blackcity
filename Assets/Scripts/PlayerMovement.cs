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

        ActivateRunningAnimation();

        ActivateJumpAnimation();

        ActivateAttackAnimation();

    }

    private void ActivateAttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            animator.SetBool("isAttacking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);

            StartCoroutine(StopAttack());
        }
    }

    private void ActivateJumpAnimation()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }

    private void ActivateRunningAnimation()
    {
        if (move < 0)
        {

            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRunning", true);
        }
        else if (move > 0)
        {

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRunning", true);
        }
        else if (move == 0)
            animator.SetBool("isRunning", false);
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
            animator.SetBool("isJumping", false);
            animator.GetBool("isJumping");
        }

    }


    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAttacking", false);
    }


}
