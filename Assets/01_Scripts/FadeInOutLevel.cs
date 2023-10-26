using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutLevel : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;


    private void Update()
    {
        if (playerHealth.Health <= 0)
        {
            GetComponent<Animator>().Play("FadeOut");
        }
        if (playerHealth.Health > 0)
        {
            GetComponent<Animator>().Play("FadeIn");
        }

    }


}
