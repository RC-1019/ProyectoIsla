using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao_linterna : MonoBehaviour
{
    public GameObject lantern;
    public AudioSource Sonido;
    public AudioClip soundFX;

    public void OnGetBattery()
    {
        gameObject.SetActive(false);
        Sonido.transform.position = transform.position;
        Sonido.PlayOneShot(soundFX);
    }
}
