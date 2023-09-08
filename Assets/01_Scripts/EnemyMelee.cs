using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour, IHealth
{
    [SerializeField] float health = 500;
    private GameObject weapon;
    public float Health { get => health; set => health = value; }

    private void Start()
    {
        Health = health;
        weapon = GetComponent<EnemyAI>().Weapon;
    }

    public void CheckHealth()
    {
        if (Health <= 0)
        {
            GetComponent<Animator>().Play("Enemy_Dying");
            weapon.SetActive(false);
            Invoke("DestroyItself", 0.5f);
        }

    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
