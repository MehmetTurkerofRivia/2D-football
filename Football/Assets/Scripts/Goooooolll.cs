using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goooooolll : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip collisionSound; // �arp��ma sesi

    void Start()
    {
        // AudioSource bile�enini almak i�in GetComponent kullan�l�r
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
