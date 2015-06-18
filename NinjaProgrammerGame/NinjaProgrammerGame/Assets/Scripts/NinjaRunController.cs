using UnityEngine;
using System.Collections;
using System;

public class NinjaRunController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float forwardSpeed = 15f;
    public float jumpSpeed = 500;
    public float halfJumpSpeed;
    public float maxSpeed = 100f;

    private bool didClick;
    private bool isDead;
    private bool isGrounded;
    private bool isAbleToDD;
    private bool didDD;

    public float floorPossition;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.halfJumpSpeed = this.jumpSpeed / 2;
    }
    public void Update()
    {
         if (Input.GetButtonDown("Fire1") && !this.isDead)
         {
             didClick = true;
         }
        if(this.transform.position.y < 1.85f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

         Debug.Log(didClick);
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

            this.rb.AddForce(new Vector2(0, halfJumpSpeed));

            var updatedVelocity = this.rb.velocity;
            if (updatedVelocity.y > this.maxSpeed)
            {
                updatedVelocity.y = this.maxSpeed;
                this.rb.velocity = updatedVelocity;
            }
        }
        else
        {
            didClick = false;
        }
    }
}
