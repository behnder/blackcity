using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color newColor;
    private SpriteRenderer mySprite;


    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.color = newColor;
    }
}
