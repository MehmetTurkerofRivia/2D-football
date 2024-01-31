using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goooooolll : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip collisionSound; // Çarpýþma sesi

    void Start()
    {
        // AudioSource bileþenini almak için GetComponent kullanýlýr
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

}
