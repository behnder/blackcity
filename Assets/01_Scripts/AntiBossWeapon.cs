using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBossWeapon : MonoBehaviour
{
    //[SerializeField] GameObject bulletPrefab;
    private bool canShoot = false;
    private bool direction = true;
    private bool isFirstShot = true;
    [SerializeField] float shootingDelay = 1f;
    [SerializeField] float bulletVelocity = 15f;



    private void Start()
    {
      
        GameObject bullet = AntiBossWeaponPool.instance.GetPooledObject();

    }

    private void Update()
    {
        #region manual shoot(delete this)
        if (Input.GetButtonDown("Fire2"))
        {
            Invoke("Shoot", 0f);
        }
        #endregion
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerWeapon01"))
        {
         
        
            Shoot();
            Invoke("ChangePosition", 1f);

        }

    }
    private void Shoot()
    {
        GetComponent<Animator>().SetBool("isShooting", true);
        GameObject bullet = AntiBossWeaponPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position + new Vector3(0, 0, 2);
            bullet.transform.rotation = transform.rotation;

            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            bullet.SetActive(true);
            print("Im a bullet active, my position is "+ bullet.transform.position);
            if (direction)
            {
                bulletRigidbody.velocity = transform.right * bulletVelocity;

            }
            else if (!direction)
            {
                bulletRigidbody.velocity = transform.right * -bulletVelocity;

            }
        }

        isFirstShot = false;
    }

    private void ChangePosition()
    {
        GetComponent<Animator>().SetBool("isShooting", false);
        
        if (direction)
        {
            //position
            gameObject.transform.Translate(new Vector3(23, 0));

            //scale
            Vector3 localScale = gameObject.transform.localScale;
            localScale.x = -Mathf.Abs(localScale.x);
            gameObject.transform.localScale = localScale;

            direction = false;
        }
        else if (!direction)
        {
            //position
            gameObject.transform.Translate(new Vector3(-23, 0));

            //scale
            Vector3 localScale = gameObject.transform.localScale;
            localScale.x = Mathf.Abs(localScale.x);
            gameObject.transform.localScale = localScale;

            direction = true;
        }
    }
}
