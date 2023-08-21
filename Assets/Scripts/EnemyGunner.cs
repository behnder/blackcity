using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float shootingDelay = 1f;
    [SerializeField] float gunOffset;
    [SerializeField] float distanceToActivateGun = 10f;

    [SerializeField] Transform gunTransform;
    private bool canShoot = true;

    private void Start()
    {
        //gunTransform = transform.Find("Gun");
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
            gunTransform.rotation = Quaternion.Slerp(gunTransform.rotation, Quaternion.Euler(0, 0, angle + gunOffset), Time.deltaTime * rotationSpeed);

            // Shoot if the shooting delay has passed and the enemy can shoot
            if (canShoot)
            {
                StartCoroutine(ShootCoroutine());
            }
        }
    }

    private IEnumerator ShootCoroutine()
    {
        canShoot = false; // Prevent shooting while the coroutine is running

        yield return new WaitForSeconds(shootingDelay);

        // Create a bullet and shoot it in the gun's direction
        //GameObject bullet = Instantiate(bulletPrefab, gunTransform.position + new Vector3(0, 0, 2), gunTransform.rotation);

        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            //bullet.transform.position = bulletPosition
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            bulletRigidbody.velocity = gunTransform.right * 10f; // Adjust bullet speed as needed
        }

        canShoot = true; // Allow shooting again


    }
}
