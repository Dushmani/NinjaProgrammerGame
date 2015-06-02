using UnityEngine;
using System.Collections;
using System;

public class BackgroundColliderController : MonoBehaviour
{
    private int numberOfBackgrounds;
    private float distanceBetweenBackgrounds;

    public void Start()
    {
        var backgrounds = GameObject.FindGameObjectsWithTag("Background");
        
        this.numberOfBackgrounds = backgrounds.Length;

        if(this.numberOfBackgrounds<2)
        {
            throw new InvalidOperationException("You must have atleast 2 backgrounds");
        }
        this.distanceBetweenBackgrounds
            = Mathf.Abs(
                backgrounds[0].transform.position.x
                - backgrounds[1].transform.position.x);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Background"))
        {
            Debug.Log(distanceBetweenBackgrounds);
            var background = collider.gameObject;
            var bgPosition = background.transform.position;
            bgPosition.x += this.numberOfBackgrounds * distanceBetweenBackgrounds;
            background.transform.position = bgPosition;
        }

    }

}
