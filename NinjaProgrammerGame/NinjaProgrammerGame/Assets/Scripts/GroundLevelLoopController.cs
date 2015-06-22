using UnityEngine;
using System.Collections;

public class GroundLevelLoopController : MonoBehaviour
{

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

        Debug.Log(distanceBetweenBackgrounds);
        Debug.Log(numberOfBackgrounds);

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Background")
            || collider.CompareTag("Losh")
            || collider.CompareTag("Egg")
            || collider.CompareTag("Floor"))
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
            
            else if(collider.CompareTag("Background"))
            {
                originalPosition.x
                    += this.numberOfBackgrounds
                    * this.distanceBetweenBackgrounds;
            }
            else if(collider.CompareTag("Floor"))
            {
                originalPosition.x
                    += this.numberOfFloors
                    * this.distanceBetweenFloors;
            }
            else if (collider.CompareTag("Egg"))
            {
                originalPosition.x =
                    GameObject.FindGameObjectWithTag("Boss").transform.position.x;
                originalPosition.y =
                    GameObject.FindGameObjectWithTag("Boss").transform.position.y;
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

   
    private float DistanceBetweenObjects(GameObject[] gameObjects)
    {
        float minDistance = float.MaxValue;

        for (int i = 1; i < gameObjects.Length; i++)
        {
            var currentDistance = Mathf.Abs(
                gameObjects[i].transform.position.x
                - gameObjects[i - 1].transform.position.x);

            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
            }
        }

        return minDistance;
    }

}
