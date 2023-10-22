using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    private Animator anim;

    public bool groundChecker;

    private void Start()
    {
         anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundChecker = true;
       
            //anim.Play("Land_Dust");
        }
    }

}
