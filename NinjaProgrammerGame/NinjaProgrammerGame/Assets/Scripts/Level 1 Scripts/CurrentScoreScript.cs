using UnityEngine;
using System.Collections;

public class CurrentScoreScript : MonoBehaviour {

    public GameObject player;
    private float distance;
    private int multiplier;
    private int currentScore;
    private int highScore;

    public GUIStyle largeFont;


    void Start()
    {
        this.multiplier = 10;
        this.currentScore = 0;

        largeFont = new GUIStyle();

        largeFont.fontSize = 32;
    }

    void Update()
    {
        this.distance = player.transform.position.x;
        this.currentScore = (int)distance * multiplier;

        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }
    public void OnGUI()
    {
         GUI.Label(new Rect(10, 0, 100, 20), "Score:" + currentScore, largeFont);

    }
}
