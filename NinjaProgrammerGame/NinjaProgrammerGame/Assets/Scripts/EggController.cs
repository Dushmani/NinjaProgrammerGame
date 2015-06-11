using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {


    public GameObject player;
    public GameObject boss;
    private float bossPositionX;
    private float bossPositionY;

    private float eggPositionY;
    private float eggPositionX;

    private float playerPosition;
    private float distanceBetweenObejcts;
    public float distanceForRespawn;

	public void Start () 
    {
        bossPositionX = boss.transform.position.x;
        bossPositionY = boss.transform.position.y;

        this.eggPositionX = this.transform.position.x;
        this.eggPositionY = this.transform.position.y;

        distanceForRespawn = 7f;

        this.playerPosition = player.transform.position.x;

        this.distanceBetweenObejcts = playerPosition - eggPositionX;

	}
	
	public void Update () 
    {
        if(distanceBetweenObejcts > distanceForRespawn)
        {
            this.eggPositionX = bossPositionX;
            this.eggPositionY = bossPositionY;
        }
	}
    public void OnTriggerEnter2D(Collider2D collider)
    {
    }

}
