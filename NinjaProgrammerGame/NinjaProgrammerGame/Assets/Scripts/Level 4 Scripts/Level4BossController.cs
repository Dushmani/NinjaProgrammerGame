using UnityEngine;
using System.Collections;

public class Level4BossController : MonoBehaviour
{

    public GameObject player;
    private Animator anim;

    public float forwardSpeed;

    public void Start()
    {
        //    this.forwardSpeed = 0.155f;

        this.anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (anim.GetBool("BossDead") == true)
        {
            this.forwardSpeed = 0;
        }
    }

    public void FixedUpdate()
    {
        var possition = transform.position;
        possition.x += forwardSpeed;
        this.transform.position = possition;

    }
}
