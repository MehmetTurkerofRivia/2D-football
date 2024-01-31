using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BotAi : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform ballAim;

    float MoveSpeed = 3f ;
    float smooth = 3f;
    void Update()
    {  
        transform.position = Vector3.MoveTowards(gameObject.transform.position, ball.transform.position, MoveSpeed * Time.deltaTime);   
    }
}
