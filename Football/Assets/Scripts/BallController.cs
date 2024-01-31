using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float kickForce = 10f;
    float DriblingForce = 0.1f;
    private Rigidbody ballRb;
    float zamanSuresi = 5f;
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();         
        Invoke("HiziSifirla", zamanSuresi);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �arp��an nesnenin tag'ini kontrol et
        if (collision.collider.CompareTag("Player"))
        {
            // Oyuncunun y�n�ne ba�l� olarak kuvvet uygula
            Vector3 DriblingDirection = collision.gameObject.transform.up;
            ballRb.AddForce(DriblingDirection * DriblingForce, ForceMode.Impulse);

            if (collision.collider.CompareTag("ShotLeg"))
            {
                // Oyuncunun y�n�ne ba�l� olarak kuvvet uygula
                Vector3 kickDirection = collision.gameObject.transform.up;
                ballRb.AddForce(kickDirection * kickForce, ForceMode.Impulse);
            }

            if (collision.collider.CompareTag("OutOfArena"))
            {
                // Oyuncunun y�n�ne ba�l� olarak kuvvet uygula
                Vector3 kickDirection = collision.gameObject.transform.up;
                ballRb.AddForce(kickDirection * 0.5f, ForceMode.Impulse);
            }
        }       
    }
    void HiziSifirla()
    {
        // Topun h�z�n� s�f�rla
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
    }
}
