using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject player;
    public int starSpeed;


    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.anim = player.GetComponent<Animator>();
        this.starSpeed = -2;
    }

    void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);

        if (anim.GetBool("didWin") == true
            || anim.GetBool("NinjaDead") == true)
        {
            this.starSpeed = 0;
        }

    }
    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.starSpeed;
        this.rb.velocity = velocity;

        this.rb.AddForce(new Vector2(starSpeed, 0));

    }
}
 
    
    
   
        
    
