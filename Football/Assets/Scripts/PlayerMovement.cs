using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movespeed = 7;
    public Rigidbody2D rb;
    public Vector2 moveDirection;
    Animator animator;
    BoxCollider2D ShotCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ShotCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        movement();
        sprint();
        WalkAnimation();
        ShotAnimation();
    }

    private void FixedUpdate()
    {
        move();
        rotation();
    }

    void movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void move()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
    }

    private void sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed = 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movespeed = 7;
        }
        Debug.Log(movespeed);
    }
    private void rotation()
    {
     if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }   
    }

    private void ShotAnimation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Shot());
        }
    }

    private void WalkAnimation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("Walk", movespeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Walk", movespeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("Walk", movespeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Walk", movespeed);
        }
    }
    IEnumerator Shot()
    {
        movespeed = 0;
        animator.SetBool("Shot", true);
        ShotCollider.enabled = true;
        animator.SetBool("Shot", false);
        ShotCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        movespeed = 7;
    }
}
