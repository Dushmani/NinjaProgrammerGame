using UnityEngine;
using System.Collections;
using System;

public class NinjaFlyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Animator bossAnimator;
    public GameObject boss;
    private Rigidbody2D bossRb;
    private BoxCollider2D boxColl;

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
        this.bossRb = boss.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.bossAnimator = boss.GetComponent<Animator>();
        this.boxColl = this.GetComponent<BoxCollider2D>();

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
    //public void OnCollisionEnter2D(Collision2D collider)
    //{
    //    if (collider.gameObject.CompareTag("Losh")
    //        || collider.gameObject.CompareTag("Egg"))
    //    {

    //        this.isDead = true;
    //        this.animator.SetBool("NinjaDead", true);
    //        forwardSpeed = 0;
    //    }


    //}
    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Boss"))
        {

            this.animator.SetBool("didWin", true);
            bossRb.isKinematic = false;
            this.forwardSpeed = 0;
            rb.isKinematic = true;
			Application.LoadLevel("Level 4");

        }
        if (trigger.gameObject.CompareTag("Losh")
           || trigger.gameObject.CompareTag("Egg"))
        {

            this.isDead = true;
            this.animator.SetBool("NinjaDead", true);
            boxColl.isTrigger = true;
            forwardSpeed = 0;
			Application.LoadLevel(Application.loadedLevel); // 22.06.2015 01:42 
			                                                //imam da pisha po matematika 6 lista 
			                                                //a sled 6 chasa sum na uchiliste :@:@ -pon0
			                                                // Reading Code Is Key to Writing Good Code - Steven Harman
        }
    }
}
