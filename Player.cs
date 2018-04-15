﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;

    FloatingJoystick theJoystick;

    Animator anim;

    bool grounded = false;
    //public Transform groundCheck;
    //float groundRadius = .2f;
    //public LayerMask whatIsGround;
    public float jumpForce = 700f;

    Rigidbody2D playerRB2D;

    bool doubleJump = false;

    void Start()
    {
        //anim = GetComponent<Animator>();
        playerRB2D = GetComponent<Rigidbody2D>();
        playerRB2D.velocity = new Vector2(0, 0);
        theJoystick = FindObjectOfType<FloatingJoystick>();
    }

    void FixedUpdate()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;


        //anim.SetFloat("vSpeed", playerRB2D.velocity.y);

        //float move = Input.GetAxis("Horizontal");
        //float move = theJoystick.getDirection();
        float move = theJoystick.Horizontal;

        //anim.SetFloat("Speed", Mathf.Abs(move));

        playerRB2D.velocity = new Vector2(move * maxSpeed, playerRB2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Update()
    {
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void jump()
    {
        if ((grounded || !doubleJump))
        {
            //anim.SetBool("Grounded", false);
            playerRB2D.AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded)
                doubleJump = true;

            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//reset the jump counts
        {
            grounded = true;
            doubleJump = false;
        }
    }
}
