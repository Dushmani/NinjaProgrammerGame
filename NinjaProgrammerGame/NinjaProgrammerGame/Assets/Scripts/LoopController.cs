using UnityEngine;
//NEED NAME FIX
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
        this.numberOfBackgrounds = backgrounds.Length;

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        this.numberOfEnemies = enemies.Length;

        RandomizeEnemies(enemies);

        if (this.numberOfBackgrounds < 2
            || this.numberOfEnemies < 2)
        {
            throw new System.InvalidOperationException("You must have atleast 2 backgrounds or Enemies");
        }
        this.distanceBetweenBackgrounds
            = this.DistanceBetweenObjects(backgrounds[0], backgrounds[1]);
        this.distanceBetweenEnemies
           = this.DistanceBetweenObjects(enemies[0], enemies[1]);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("nq be");
        }
        if (collider.CompareTag("Background")
            || collider.CompareTag("Enemy"))
        {
            var go = collider.gameObject;
            var originalPossition = go.transform.position;

            if (collider.CompareTag("Enemy"))
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
        int count = 0;
        for (int i = 1; i < enemies.Length; i++)
        {
            count++;
            var currentEnemy = enemies[i];
            float randomY;

            if (count % 2 == 0) //upper enemy
            {

                randomY = Random.Range(-1.5f, 0);
            }
            else            //Mark Knight - DOWNPIPE (music)
            {

                randomY = Random.Range(1, 4.5f);
            }
            var enemyPossition = currentEnemy.transform.position;
            enemyPossition.y = randomY;
            currentEnemy.transform.position = enemyPossition;
        }
    }

}
