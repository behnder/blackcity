using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
   
    [SerializeField] private bool isJumping;
    [SerializeField] float move;
    [SerializeField] GameObject weapon;

    private Animator animator;

    private void Start()
    {

        animator = GetComponent<Animator>();

    }

    private void Update()
    {

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
            print("jumping");
            isJumping = true;
            animator.SetBool("isJumping", true);
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
