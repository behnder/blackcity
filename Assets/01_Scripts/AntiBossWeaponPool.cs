using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBossWeaponPool : MonoBehaviour
{
    public static AntiBossWeaponPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 5;

    [SerializeField] private GameObject bullet;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooledObjects.Add(obj);

        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];

            }
        }
        return null;
    }
}
