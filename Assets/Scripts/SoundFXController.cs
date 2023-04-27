using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : MonoBehaviour
{
    [SerializeField] AudioSource WallSFX, RacketSFX;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Racket")
            RacketSFX.Play();
        else
            WallSFX.Play();
    }
}
