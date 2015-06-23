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
        StartCoroutine(WaitForStart());

        this.forwardSpeed = 5f;

        this.anim.SetBool("didClick", true);




	}
    public void Update()
    {

        Debug.Log(anim.GetBool("didClick"));
    }

    public void FixedUpdate()
    {
        var velocity = this.rb.velocity;
        velocity.x = this.forwardSpeed;
        this.rb.velocity = velocity;
    }
    public IEnumerator WaitForStart()
    {

        
        yield return new WaitForSeconds(2);
        Application.LoadLevel("Level 1");

    }

    

}
