﻿using UnityEngine;
using System.Collections;

public class GroundLevelLoopController : MonoBehaviour
{

    private int numberOfBackgrounds;
    private float distanceBetweenBackgrounds;

    private int numberOfEnemies;
    private float distanceBetweenEnemies;

    private bool upperEnemy;


    public void Start()
    {

        var backgrounds = GameObject.FindGameObjectsWithTag("Background");
        var enemies = GameObject.FindGameObjectsWithTag("Losh");

        this.numberOfBackgrounds = backgrounds.Length;
        this.numberOfEnemies = enemies.Length;


        if (this.numberOfBackgrounds < 2
            || this.numberOfEnemies < 2)
        {
            throw new System.InvalidOperationException("You must have atleast 2 backgrounds or Enemies");
        }
        this.distanceBetweenBackgrounds
            = this.DistanceBetweenObjects(backgrounds);
        this.distanceBetweenEnemies
            = this.DistanceBetweenObjects(enemies);

        Debug.Log(numberOfBackgrounds);
        Debug.Log(distanceBetweenBackgrounds);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Background")
            || collider.CompareTag("Losh"))
        {

            var go = collider.gameObject;
            var originalPosition = go.transform.position;

            if (collider.CompareTag("Losh"))
            {
                float randomX;
                randomX = Random.RandomRange(-5.5f,5.5f);
                originalPosition.x +=
                     this.numberOfEnemies
                     * this.distanceBetweenEnemies
                         +randomX;

            }
            
            else
            {
                originalPosition.x
                    += this.numberOfBackgrounds
                    * this.distanceBetweenBackgrounds;
            }
            go.transform.position = originalPosition;


        }


    }
    private float DistanceBetweenObjects(GameObject first, GameObject second)
    {
        return Mathf.Abs(
                first.transform.position.x
                - second.transform.position.x);
    }

    private void RandomizeEnemies(GameObject[] enemies)
    {
        //FIX FIRST 0 ENEMIES SPAWN
        int count = 0;

        for (int i = 1; i < enemies.Length; i++)
        {
            count++;
            var currentPipe = enemies[i];
            float randomY;
            if (count % 2 == 0) // upper Enemy
            {
                randomY = Random.Range(-0.5f, 2);
            }
            else // Mark Knight - DOWNPIPE (D-ramiraz remix)
            {
                randomY = Random.Range(-2.5f, 0);
            }

            var pipePosition = currentPipe.transform.position;
            pipePosition.y = randomY;
            currentPipe.transform.position = pipePosition;
        }
    }
    private float DistanceBetweenObjects(GameObject[] gameObjects)
    {
        float minDistance = float.MaxValue;

        for (int i = 1; i < gameObjects.Length; i++)
        {
            var currentDistance = Mathf.Abs(
                gameObjects[i - 1].transform.position.x
                - gameObjects[i].transform.position.x);

            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
            }
        }

        return minDistance;
    }

}
