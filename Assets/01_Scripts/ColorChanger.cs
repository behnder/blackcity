using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color newColor;
    private SpriteRenderer mySprite;


    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.color = newColor;
    }
}
   
