using UnityEngine;
using System.Collections;
using System;

public class NinjaRunController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float forwardSpeed = 15f;
    public float jumpSpeed = 5f;
    public float halfJumpSpeed;
    public float maxSpeed = 100f;

    private bool didClick;
    private bool isDead;
    private bool isGrounded;
    private bool isAbleToDD;

    public float floorPossition;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.halfJumpSpeed = this.jumpSpeed / 2;
    }
    public void Update()
    {
         if (Input.GetButtonDown("Fire1") && !this.isDead && this.isGrounded)
         {
             didClick = true;
             isAbleToDD = true;
         }
         else if(Input.GetButton("Fire1") && !this.isDead && !this.isGrounded && this.isAbleToDD)
         {
             isAbleToDD = true; ;
         }
        if(this.transform.position.y < 1.85f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //Addd thigs with floor! -za mene si go pi6a!

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

            this.rb.AddForce(new Vector2(0, jumpSpeed));

            var updatedVelocity = this.rb.velocity;
            if (updatedVelocity.y > this.maxSpeed)
            {
                updatedVelocity.y = this.maxSpeed;
                this.rb.velocity = updatedVelocity;
            }

        }
        else if (didClick && isAbleToDD)
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
    }
}
