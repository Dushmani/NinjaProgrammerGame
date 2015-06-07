using UnityEngine;
public class LoopController : MonoBehaviour
{
    private int numberOfBackgrounds;
    private float distanceBetweenBackgrounds;

    private int numberOfEnemies;
    private float distanceBetweenEnemies;
    private bool upperEnemy;
    private bool downEnemy;

    public void Start()
    {
        var backgrounds = GameObject.FindGameObjectsWithTag("Background");
        var enemies = GameObject.FindGameObjectsWithTag("Losh");

        this.numberOfBackgrounds = backgrounds.Length;
        this.numberOfEnemies = enemies.Length;

        RandomizeEnemies(enemies);

        if (this.numberOfBackgrounds < 2
            || this.numberOfEnemies < 2)
        {
            throw new System.InvalidOperationException("You must have atleast 2 backgrounds or Enemies");
        }
        this.distanceBetweenBackgrounds
            = this.DistanceBetweenObjects(backgrounds);
        this.distanceBetweenEnemies
            = this.DistanceBetweenObjects(enemies);
            

        Debug.Log(distanceBetweenEnemies);
        Debug.Log(numberOfEnemies);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Losh"))
        {
            Debug.Log("nq be");
        }
        if (collider.CompareTag("Background")
            || collider.CompareTag("Losh"))
        {
            var go = collider.gameObject;
            var originalPossition = go.transform.position;

            if (collider.CompareTag("Losh"))
            {
                originalPossition.x
                    += this.numberOfEnemies
                    * this.distanceBetweenEnemies;

                float randomY;
                if (upperEnemy) //upper enemy
                {

                    randomY = Random.Range(-1.5f, 0);

                }
                else            //Mark Knight - DOWNPIPE (music)
                {

                    randomY = Random.Range(1, 4.5f);
                }
                originalPossition.y = randomY;
                this.upperEnemy = !this.upperEnemy;
            }
            else if (collider.CompareTag("Background"))
            {

                originalPossition.x
                    += this.numberOfBackgrounds
                    * this.distanceBetweenBackgrounds;
            }
            go.transform.position = originalPossition;

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
                randomY = Random.Range(1.5f, 3);
            }
            else // Mark Knight - DOWNPIPE (D-ramiraz remix)
            {
                randomY = Random.Range(-1, 0.5f);
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
