using UnityEngine;
using System.Collections;

public class LoopController1 : MonoBehaviour {
    private int numberOfBackgrounds;
    private float distanceBetweenBackgrounds;

    private int numberOfEnemies;
    private float distanceBetweenEnemies;

    private int numberOfFloors;
    private float distanceBetweenFloors;

    private bool upperEnemy;


    public void Start()
    {

        var backgrounds = GameObject.FindGameObjectsWithTag("Background");
        var enemies = GameObject.FindGameObjectsWithTag("Losh");
        var floors = GameObject.FindGameObjectsWithTag("Floor");

        this.numberOfBackgrounds = backgrounds.Length;
        this.numberOfEnemies = enemies.Length;
        this.numberOfFloors = floors.Length;


        if (this.numberOfBackgrounds < 2
            || this.numberOfEnemies < 2)
        {
            throw new System.InvalidOperationException("You must have atleast 2 backgrounds or Enemies");
        }
        this.distanceBetweenBackgrounds
            = this.DistanceBetweenObjects(backgrounds);
        this.distanceBetweenEnemies
            = this.DistanceBetweenObjects(enemies);
        this.distanceBetweenFloors
            = this.DistanceBetweenObjects(floors);

        Debug.Log(distanceBetweenEnemies);
        Debug.Log(numberOfEnemies);

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Background")
            || collider.CompareTag("Losh")
            || collider.CompareTag("Floor"))
        {

            var go = collider.gameObject;
            var originalPosition = go.transform.position;

            if (collider.CompareTag("Losh"))
            {
                float randomX;
                randomX = Random.RandomRange(-7.5f, 7.5f);
                originalPosition.x +=
                     this.numberOfEnemies
                     * this.distanceBetweenEnemies
                         + randomX;

            }

            else if (collider.CompareTag("Background"))
            {
                originalPosition.x
                    += this.numberOfBackgrounds
                    * this.distanceBetweenBackgrounds;
            }
            else if (collider.CompareTag("Floor"))
            {
                originalPosition.x
                    += this.numberOfFloors
                    * this.distanceBetweenFloors;
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
