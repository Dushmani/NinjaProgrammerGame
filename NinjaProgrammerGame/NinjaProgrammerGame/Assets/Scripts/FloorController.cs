using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour
{

    private Rigidbody2D rb;
    public int floorSpeed = -2;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.floorSpeed;
        this.rb.velocity = velocity;

        this.rb.AddForce(new Vector2(floorSpeed, 0));

    }
}



