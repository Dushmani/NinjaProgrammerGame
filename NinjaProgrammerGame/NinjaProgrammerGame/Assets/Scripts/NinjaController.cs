using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool didClick;

    public float clickSpeed = 100f;
    public float forwardSpeed = 15f;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
            this.rb.AddForce(new Vector2(0,clickSpeed));
        }
    }
}
