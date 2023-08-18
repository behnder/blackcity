using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    [SerializeField] private bool isJumping;
    [SerializeField] float move;
    [SerializeField] GameObject weapon;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GroundChecker groundChecker;
    private Animator animator;
    private float speed;

    private void Start()
    {

        animator = GetComponent<Animator>();
 
        speed = playerMovement.Speed;


    }

    private void Update()
    {

        ActivateRunningAnimation();


        ActivateAttackAnimation();
        ActivateJumpAnimation();
        ActivateAirAttackAnimation();

        ActivateCrouchAnimation();

    }

    private void ActivateCrouchAnimation()
    {
        if (Input.GetAxis("Vertical") < 0)

        {
            animator.SetBool("isCrouching", true);
        }
        else
        {
            animator.SetBool("isCrouching", false);

        }
    }

    private void ActivateAirAttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isJumping)
            {
                animator.SetBool("isAirAttacking", true);
                playerMovement.Speed = 2;

            }

         
        }
    }

    private void ActivateAttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isJumping)
            {
                animator.SetBool("isAttacking", true);
                playerMovement.Speed = 2;

            }
     

            playerMovement.Move = 0;
            playerMovement.rb.velocity = new Vector2(0, playerMovement.rb.velocity.y);

          
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);

            StartCoroutine(StopAttack());
        }

    }

    private void ActivateJumpAnimation()
    {

        if (groundChecker.groundChecker)
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isAirAttacking", false);
        }
        else
        {
            isJumping = true;
        }
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("isAttacking", false);
                animator.SetBool("isAirAttacking", true);
            }
        }
    }

    private void ActivateRunningAnimation()
    {
        move = Input.GetAxis("Horizontal");
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

    //are called in the animation (attack-punch animation)
    private void ActivateWeapon()
    {
        weapon.SetActive(true);
    }
    private void DeactivateWeapon()
    {
        weapon.SetActive(false);
    }
    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAttacking", false);
        playerMovement.Speed = 6.5f;

    }
}
