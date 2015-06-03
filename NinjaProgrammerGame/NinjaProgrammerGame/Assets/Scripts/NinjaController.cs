using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    

    private bool didClick;
    private bool isDead;

    public float clickSpeed = 100f;
    public float forwardSpeed = 15f;
    public float maxSpeed = 100f;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !this.isDead)
        {
            this.didClick = true;
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
            if(updatedVelocity.y > this.maxSpeed)
            {
                updatedVelocity.y = this.maxSpeed;
                this.rb.velocity = updatedVelocity;
            }

        }
    }
    // LTB BULLET CONTROLLER NEED REPAIR, PON0 BONAK MRUSEN
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            this.isDead = true;
            this.animator.SetBool("NinjaDead", true);

            // fix dieing in air
        }


    }
}
