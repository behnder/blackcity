using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField]GameObject bossHealth;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (bossHealth.GetComponent<EnemyMelee>().Health <= 0)
        {
            Invoke("LoadScene", 2f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
