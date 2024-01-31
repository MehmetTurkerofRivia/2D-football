using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraFollowing : MonoBehaviour
{
    [SerializeField] Transform CameraFollowing;

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x , CameraFollowing.transform.position.y ,gameObject.transform.position.z);   
    }
}
