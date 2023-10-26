using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExternalCollider : MonoBehaviour
{
    private Transform parentTransform;
    private Transform childTransform;

    private void Start()
    {
        // Get references to the parent and child transforms
   // Replace with the correct index or reference to your child

        // Reset the child's position and rotation to match the parent

        InvokeRepeating("ResetChildToParentTransform", 0f,0.5f);
        //ResetChildToParentTransform();
    }

    private void ResetChildToParentTransform()
    {
        // Set the child's position and rotation to match the parent
        parentTransform = transform;
        childTransform = transform.GetChild(0);
        childTransform.position = parentTransform.position;
        childTransform.rotation = parentTransform.rotation;
    }
}
