using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHealth 
{
   
    float Health { get; set; }

    // Start is called before the first frame update
    void CheckHealth();
}
