using UnityEngine;
using System.Collections;

public class NinjaStartMenuScript : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("ColliderGameStart"))
        {
            Debug.Log("trebva da po4ne");
            Application.LoadLevel("Level 1");

        }


    }
}
