using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public GameObject player;

    public int floorSpeed;


    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.anim = player.GetComponent<Animator>();
        this.floorSpeed = -2;
    }

    void Update()
    {
        if (anim.GetBool("didWin") == true
            || anim.GetBool("NinjaDead") == true)
        {
            this.floorSpeed = 0;
        }

    }
    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.floorSpeed;
        this.rb.velocity = velocity;

        this.rb.AddForce(new Vector2(floorSpeed, 0));

    }
}



