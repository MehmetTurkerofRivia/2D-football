using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goooooolll : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip collisionSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Debug.Log("a");
    
            audioSource.PlayOneShot(collisionSound);
        }
    }

}
