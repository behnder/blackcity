using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{

    [SerializeField] private bool isJumping;
    [SerializeField] float move;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject airWeapon;
    //[SerializeField] Text yPos;
    //[SerializeField] Text xPos;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GroundChecker groundChecker;
    private Animator animator;
    [SerializeField] GameObject groundCheckerActivator;
    private float speed;

    [Header("Audio")]
    [Space(10)]
    [SerializeField] AudioSource groundHit;
    [SerializeField] AudioSource airHit;
    [SerializeField] GameObject steps;


    private void Start()
    {
        animator = GetComponent<Animator>();

        speed = playerMovement.Speed;
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {

            ActivateRunningAnimation();

            ActivateAttackAnimation();
            ActivateJumpAnimation();

            ActivateCrouchAnimation();
            ActivateIdleAnimation();

            ActivateAirAttackAnimation();
            CheckAirAttackAnimation();

            if (Mathf.Round(playerMovement.rb.velocity.y) != 0)
            {
                groundCheckerActivator.SetActive(false);
            }
            else
            {
                groundCheckerActivator.SetActive(true);

            }
        }
    }

    private void CheckAirAttackAnimation()
    {

        if (groundChecker.groundChecker == true)
        {
            airWeapon.SetActive(false);
        }
    }

    IEnumerator DelayGroundCheckerActivation()
    {
        yield return new WaitForSeconds(0.6f);
        if (Mathf.Round(playerMovement.rb.velocity.y) == 0)
        {

            groundCheckerActivator.SetActive(true);

        }

    }
    private void ActivateIdleAnimation()
    {
        if (!isJumping)
        {
            animator.SetBool("isAirAttacking", false);
        }
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
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.K)) && isJumping)
        {
            animator.SetBool("isAirAttacking", true);
            animator.SetBool("isRunning", false);

        }


    }

    private void ActivateAttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.K))
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
            steps.SetActive(false);
        }
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            steps.SetActive(false);
            animator.SetBool("isJumping", true);
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.K))
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
            steps.SetActive(true);

            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRunning", true);
        }
        else if (move > 0)
        {

            steps.SetActive(true);

            steps.SetActive(true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRunning", true);
        }
        else if (move == 0)
        {
            animator.SetBool("isRunning", false);
            steps.SetActive(false);
        }
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
    //this is called from the animator
    private void PlayHitSound()
    {
        groundHit.Play();
    }
    private void PlayAirHitSound()
    {
        airHit.Play();
    }
    private void PlayStepsSound()
    {
        steps.SetActive(true);
    }


    //this is for attacking in middle air
    private void ActivateAirWeapon()
    {
        airWeapon.SetActive(true);
    }
    private void DeactivateAirWeapon()
    {

        airWeapon.SetActive(false);

    }
    IEnumerator StopAirAttack()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAirAttacking", false);
        playerMovement.Speed = 6.5f;

    }

    IEnumerator WaitToDeactivateAirWeapon()
    {
        yield return new WaitForSeconds(0.9f);
        airWeapon.SetActive(false);
    }
}
