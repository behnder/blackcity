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
    [SerializeField] Text yPos;
    [SerializeField] Text xPos;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GroundChecker groundChecker;
    private Animator animator;
    [SerializeField] GameObject groundCheckerActivator;
    private float speed;

    private void Start()
    {

        animator = GetComponent<Animator>();

        speed = playerMovement.Speed;




    }

    private void Update()
    {
        xPos.text = "x " + Mathf.Round(playerMovement.rb.velocity.x).ToString();
        yPos.text = "y " + Mathf.Round(playerMovement.rb.velocity.y).ToString();
        ActivateRunningAnimation();

        ActivateAttackAnimation();
        ActivateJumpAnimation();

        ActivateCrouchAnimation();
        ActivateIdleAnimation();

        ActivateAirAttackAnimation();
        CheckAirAttackAnimation();

        if (Mathf.Round(playerMovement.rb.velocity.y) !=0 )
        {
            groundCheckerActivator.SetActive(false);
        }
        else
        {
            groundCheckerActivator.SetActive(true);

        }
    }

    private void CheckAirAttackAnimation()
    {
        //if (Mathf.Round(playerMovement.rb.velocity.y) == 0 && groundCheckerActivator.activeSelf == true)
        //{
        //    airWeapon.SetActive(false);
        //    StartCoroutine(DelayGroundCheckerActivation());//the delay is because with both activated, the animation is cancelled

        //}
        //else  //if groundCheckerActivator is false->
        //{
        //    groundCheckerActivator.SetActive(false);
        //    StartCoroutine(DelayGroundCheckerActivation());//the delay is because with both activated, the animation is cancelled


        //}


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
            //StartCoroutine(StopAirAttack());
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && isJumping)
        {
            animator.SetBool("isAirAttacking", true);

            //playerMovement.Move = 0; borrar?
            //playerMovement.rb.velocity = new Vector2(0, playerMovement.rb.velocity.y); borrar?

            animator.SetBool("isRunning", false);

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

    //this is for attacking in middle air
    private void ActivateAirWeapon()
    {
        airWeapon.SetActive(true);
    }
    private void DeactivateAirWeapon()
    {
        //print(GetComponent<Rigidbody2D>().velocity.y + " RIGIDBODY Y");
        ////StartCoroutine(StopAirAttack());

        //StartCoroutine(WaitToDeactivateAirWeapon());

        //if (Mathf.Abs(playerMovement.rb.velocity.x) < 0.01)
        //{
           airWeapon.SetActive(false);
        //}



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
