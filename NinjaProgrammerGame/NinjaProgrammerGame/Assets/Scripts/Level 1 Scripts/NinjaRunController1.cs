﻿using UnityEngine;
using System.Collections;
using System;

public class NinjaRunController1 : MonoBehaviour 
{
    private Rigidbody2D rb;
    private Animator animator;
    private Animator bossAnimator;
    private GameObject floor;
    public GameObject boss;

    public float forwardSpeed = 7f;
    public float jumpSpeed = 600;
    public float doubleJumpSpeed = 650;
    public float maxSpeed = 100f;
    public int floorSpeed = -20;
    private float playerDeadPossition;
    private float bossPossition;

    private bool didClick;
    private bool isDead;
    private bool isGrounded;
    private bool isAbleToDD;
    private bool didDD;



    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.bossAnimator = boss.GetComponent<Animator>();

    }
    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !this.isDead)
        {
            didClick = true;
        }
        if (this.transform.position.y < 1.85f)
        {
            isGrounded = true;

            this.animator.SetBool("didJump", false);
        }
        else
        {
            isGrounded = false;
            this.animator.SetBool("didJump", true);
            Debug.Log("skok");
        }

    }

    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.forwardSpeed;
        this.rb.velocity = velocity;


        if (didClick && this.isGrounded)
        {
            didClick = false;
            isAbleToDD = true;
            this.rb.AddForce(new Vector2(0, jumpSpeed));

            var updatedVelocity = this.rb.velocity;
            if (updatedVelocity.y > this.maxSpeed)
            {
                updatedVelocity.y = this.maxSpeed;
                this.rb.velocity = updatedVelocity;
            }

        }
        else if (didClick && isAbleToDD && !this.isGrounded)
        {
            didClick = false;
            isAbleToDD = false;

            this.rb.AddForce(new Vector2(0, doubleJumpSpeed));

            var updatedVelocity = this.rb.velocity;
            if (updatedVelocity.y > this.maxSpeed)
            {
                updatedVelocity.y = this.maxSpeed;
                this.rb.velocity = updatedVelocity;
            }
        }
        else if (isDead)
        {
            this.rb.AddForce(new Vector2(floorSpeed, 0));
            if (this.transform.position.x < playerDeadPossition - 10f)
            {
                Time.timeScale = 0;
            }
        }
        else
        {
            didClick = false;
        }


    }
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Losh")
            || collider.gameObject.CompareTag("Egg"))
        {
            this.isDead = true;
            this.animator.SetBool("NinjaDead", true);
            this.playerDeadPossition = this.transform.position.x;
            forwardSpeed = 0;
            Debug.Log("Umre");
        }


    }
    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Boss"))
        {

            this.animator.SetBool("didWin", true);
            bossAnimator.SetBool("BossDead", true);
            this.forwardSpeed = 0;
        }
    }
}
