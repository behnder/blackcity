using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShowRaycast : MonoBehaviour
{

    Vector2 origin;
    Vector2 direction;
    float distance;

    RaycastHit2D hit; 

    void Start()
    {
        
        direction = -Vector2.up;
        distance = 0.7f;

    }

    void Update()
    {
        origin = transform.position;
       // hit = Physics2D.Raycast(origin, direction, distance);
        Debug.DrawRay(origin, direction * distance, Color.green);
    }


}
