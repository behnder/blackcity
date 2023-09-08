using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivation : MonoBehaviour
{
    [SerializeField] GameObject mechanismToEnable;

    private void Start()
    {
      

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mechanismToEnable.GetComponent<Animator>().Play("Door_Open_Dissolve");
        
    }
}
