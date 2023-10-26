using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour, IHealth
{

    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject gun;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float shootingDelay = 1f;
    [SerializeField] float gunOffset;
    [SerializeField] float distanceToActivateGun = 10f;
    [SerializeField] float health = 200;
    [SerializeField] Animator gunAnimator;

    [SerializeField] Transform gunTransform;
    private bool canShoot = true;

    public float Health { get; set; }

    private void Start()
    {

        Health = health;
    }

    private void Update()
    {

        //Calculate the distance between the hero and the enemy
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= distanceToActivateGun)
        {

            // Calculate the direction to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.z = 0; // Ensure the direction is in the 2D plane

            // Calculate the rotation angle to face the player
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            // Smoothly rotate the gun towards the player
            if (gunTransform != null)
            {
                gunTransform.rotation = Quaternion.Slerp(gunTransform.rotation, Quaternion.Euler(0, 0, angle + gunOffset), Time.deltaTime * rotationSpeed);

            }

            // Shoot if the shooting delay has passed and the enemy can shoot
            if (canShoot)
            {
                //gunAnimator.GetComponent<Animator>().Play("Gunner_Gun_Shoot");

                StartCoroutine(ShootCoroutine());
            }
        }
    }

    private IEnumerator ShootCoroutine()
    {
        canShoot = false; // Prevent shooting while the coroutine is running
                          //transform.GetChild(1).GetComponent<Animator>().SetBool("isShooting",true);
        transform.GetChild(1).GetComponent<Animator>().SetBool("isShooting", false);

        yield return new WaitForSeconds(shootingDelay);
        transform.GetChild(1).GetComponent<Animator>().SetBool("isShooting", true);

        // Create a bullet and shoot it in the gun's direction (from the bullet pool)    
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = gunTransform.GetChild(0).position + new Vector3(0, 0, 2);
            bullet.transform.rotation = gunTransform.GetChild(0).rotation;
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            bullet.SetActive(true);
            bulletRigidbody.velocity = gunTransform.GetChild(0).right * 10f; // Adjust bullet speed as needed
        }
        canShoot = true; // Allow shooting again

    }

    public void CheckHealth()
    {
        if (Health <= 0)
        {
            transform.GetChild(0).GetComponent<Animator>().Play("Enemy_Dying");
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gun);
            Invoke("DestroyItself", 0.5f);
        }
    }
    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
