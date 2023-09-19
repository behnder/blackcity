using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBossWeapon : MonoBehaviour
{

    private bool direction = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            if (direction)
            {

                gameObject.transform.Translate(new Vector3(23, 0));
                direction = false;
            }
            else if(!direction)
            {
                gameObject.transform.Translate(new Vector3(-23, 0));
                direction = true;

            }

        }
    }
}
