using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletThrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ThrowTheBullet();
        }
     }

    void ThrowTheBullet()
    {

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 880));
    }
}
