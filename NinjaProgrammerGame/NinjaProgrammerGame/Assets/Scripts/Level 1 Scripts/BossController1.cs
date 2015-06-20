using UnityEngine;
using System.Collections;

public class BossController1 : MonoBehaviour {


    private float forwardSpeed;

    public void Start()
    {
        this.forwardSpeed = 0.192f;

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
