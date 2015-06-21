using UnityEngine;
using System.Collections;

public class NinjaRunController2 : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator animator;
    private GameObject floor;

    public float forwardSpeed = 10f;
    public float jumpSpeed = 600;
    public float doubleJumpSpeed = 650;
    public float maxSpeed = 100f;
    public int floorSpeed = -20;

    private bool didClick;
    private bool isDead;
    private bool isGrounded;
    private bool isAbleToDD;
    private bool didDD;


    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
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
        }
        else
        {
            didClick = false;
        }


    }
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Losh"))
        {
            this.isDead = true;
            this.animator.SetBool("NinjaDead", true);
            forwardSpeed = -2;
            Debug.Log("Umre");
        }


    }
}
