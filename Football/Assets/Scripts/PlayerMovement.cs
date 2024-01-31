using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movespeed;
    Rigidbody2D rb;
    private Vector2 moveDirection;
    Animator animator;
    [SerializeField] GameObject ShotLeg;
    float walk = 6;
    float SlowWalkSpeed = 3;
    float SprintSpeed = 9;
    float stop = 0;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();         
        WalkAnimation();
        ShotAnimation();
        SlowWalk();
        sprint();
        rotation();
        move();
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = SprintSpeed;
            animator.speed = 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movespeed = walk;
            animator.speed = 1;
        }
    }

    private void SlowWalk()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            movespeed = SlowWalkSpeed;
            animator.speed = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            movespeed = walk;
            animator.speed = 1;
        }
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
            movespeed = walk;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movespeed = stop;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            movespeed = walk;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            movespeed = stop;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movespeed = walk;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movespeed = stop;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movespeed = walk;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movespeed = stop;
            animator.SetFloat("Speed", movespeed);
            animator.SetBool("IsWalking", false);
        }
    }
    IEnumerator Shot()
    {
        movespeed = 1;
        animator.SetBool("Shot", true);
        ShotLeg.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        movespeed = 0.5f;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Shot", false);
        ShotLeg.SetActive(false);
        movespeed = walk;
    }
}
