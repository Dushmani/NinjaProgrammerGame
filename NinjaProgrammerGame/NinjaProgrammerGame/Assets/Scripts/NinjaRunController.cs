using UnityEngine;
using System.Collections;
using System;

public class NinjaRunController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float forwardSpeed = 15f;
    public float jumpSpeed = 5f;
    public float maxSpeed = 100f;

    private bool didClick;
    private bool isDead;
    private bool isGrounded;
    private bool isInAir;
    private bool areColliding;

    public float floorPossition;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();

        var floorObj = GameObject.FindGameObjectsWithTag("Floor");
        floorPossition = floorObj[0].transform.position.y;
        Debug.Log(floorPossition);
    }
    public void Update()
    {
         if (Input.GetButtonDown("Fire1") && !this.isDead && this.isGrounded)
         {
             didClick = true;
         }
         else if(Input.GetButton("Fire1") && !this.isDead && !this.isGrounded)
         {
             didClick = true;
             isInAir = true;
         }
        //Addd thigs with floor! -za mene si go pi6a!

         Debug.Log(areColliding);
    }

    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.forwardSpeed;
        this.rb.velocity = velocity;


        if (didClick && isGrounded)
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
        else if (didClick && !isGrounded)
        {
            didClick = false;
            this.rb.AddForce(new Vector2(0, jumpSpeed/2));

            var updatedVelocity = this.rb.velocity;
            if (updatedVelocity.y > this.maxSpeed)
            {
                updatedVelocity.y = this.maxSpeed;
                this.rb.velocity = updatedVelocity;
            }
        }
    }
    public void OnCollider2DEnter(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Floor"))
        { 
            areColliding = true;
        }
        Debug.Log(areColliding);
    }
}
