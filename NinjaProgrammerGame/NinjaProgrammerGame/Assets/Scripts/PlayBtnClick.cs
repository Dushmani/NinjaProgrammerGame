using UnityEngine;
using System.Collections;

public class PlayBtnClick : MonoBehaviour 
{
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    private float forwardSpeed;


    public void Start()
    {
        this.rb = player.GetComponent<Rigidbody2D>();
        this.forwardSpeed = 0;
        this.anim = player.GetComponent<Animator>();
    }
	public void PlayButtonClick()
	{
		//Application.LoadLevel("Level 1"); //ako ne se opravi level 1 she go mahneme i she imame samo 3 niva, sry :@:@
        //Application.LoadLevel("Level 2");
		Debug.Log("mai iskat da igraqt");

        this.forwardSpeed = 5f;

        this.anim.SetBool("didClick", true);


	}

    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.forwardSpeed;
        this.rb.velocity = velocity;
    }

    

}
