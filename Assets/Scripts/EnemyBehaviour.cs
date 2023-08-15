using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] float minimunDistance;
   
    private void Update()
    {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
        if (Vector2.Distance(transform.position, target.position) < minimunDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

}
