using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivation : MonoBehaviour
{
    [SerializeField] GameObject mechanismToEnable;
    [SerializeField] string animationToPlay = "Door_Open_Dissolve";

    private void Start()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            mechanismToEnable.GetComponent<Animator>().Play(animationToPlay);
            Destroy(gameObject);

        }

    }
    

}
