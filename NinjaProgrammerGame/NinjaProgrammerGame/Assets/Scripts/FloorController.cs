using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour
{

    private Rigidbody2D rb;
    public int floorSpeed;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    public void FixedUpdate()
    {
        this.rb.AddForce(new Vector2(floorSpeed, 0));
    }
}



