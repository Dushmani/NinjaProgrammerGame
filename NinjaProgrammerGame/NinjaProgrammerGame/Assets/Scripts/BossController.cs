using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public GameObject player;

    private float forwardSpeed ;

    public void Start()
    {
        this.forwardSpeed = 0.155f;

        Debug.Log(forwardSpeed);
    }

    public void Update()
    {
    }

    public void FixedUpdate()
    {
        var possition = transform.position;
        possition.x += forwardSpeed;
        this.transform.position = possition;
        
    }
}
