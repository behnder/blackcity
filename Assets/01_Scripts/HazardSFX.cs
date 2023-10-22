using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSFX : MonoBehaviour
{
    [SerializeField] AudioSource spikeHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spikeHit.Play();
    }
}
