using UnityEngine;
using System.Collections;
using System;

public class NinjaFlyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private bool didClick;
    private bool isDead;

    public float clickSpeed = 100f;
    public float forwardSpeed = 15f;
    public float maxSpeed = 100f;
    public float fallingSpeed = 0.001f;
    public float floorPossition;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();

        var floorObj = GameObject.FindGameObjectsWithTag("Floor");
        floorPossition = floorObj[0].transform.position.y;
        Debug.Log(floorPossition);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !this.isDead)
        {
            this.didClick = true;
        }
        else if (this.isDead && this.transform.position.y > floorPossition)
        {
            didClick = false;
            var deadPossition = this.transform.position;
            deadPossition.y = this.transform.position.y - fallingSpeed;
            this.transform.position = deadPossition;
        }
    }
    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.forwardSpeed;
        this.rb.velocity = velocity;

        if (didClick)
        {
            didClick = false;
            this.rb.AddForce(new Vector2(0, clickSpeed));

            var updatedVelocity = this.rb.velocity;
            if (updatedVelocity.y > this.maxSpeed)
            {
                updatedVelocity.y = this.maxSpeed;
                this.rb.velocity = updatedVelocity;
            }

        }
    }
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Losh")
            || collider.gameObject.CompareTag("Egg"))
        {
            this.isDead = true;
            this.animator.SetBool("NinjaDead", true);
            forwardSpeed = 0;
        }


    }
}
