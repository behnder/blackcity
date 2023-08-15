using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Text text;
  
   

    public float Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        Health = 300;
       
    }

    private void Update()
    {
        text.text = Health.ToString();
    }

}
