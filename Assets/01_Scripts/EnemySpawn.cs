using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] float launchForce;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
void SpawnEnemies()
    {
        Instantiate(enemy,transform.position, Quaternion.identity);

        //GameObject cannonball = Instantiate(cannonballPrefab, transform.position, Quaternion.identity);

        // Calculate the diagonal velocity (assuming 45 degrees angle).
        Vector2 launchDirection = new Vector2(-1.0f, -1.0f).normalized;

        // Apply the launch force.
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.velocity = launchDirection * launchForce;
    }
}
