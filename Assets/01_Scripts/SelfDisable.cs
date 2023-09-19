using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDisable : MonoBehaviour
{
    [SerializeField] float timeToDisable;


    private void OnEnable()
    {
        Invoke("ActivateSelfDisable", timeToDisable);

    }


    void ActivateSelfDisable()
    {
        if (gameObject != null)
        {

            gameObject.SetActive(false);
        }
    }
}
