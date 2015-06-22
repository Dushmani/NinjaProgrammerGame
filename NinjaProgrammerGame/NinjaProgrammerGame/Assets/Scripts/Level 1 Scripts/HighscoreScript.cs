using UnityEngine;
using System.Collections;

public class HighscoreScript : MonoBehaviour
{

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
        this.highScore = PlayerPrefs.GetInt("highScore");

        largeFont = new GUIStyle();

        largeFont.fontSize = 32;
    }

    void Update()
    {

        this.distance = player.transform.position.x;
        this.currentScore = (int) distance*multiplier;

        if (currentScore > highScore )
        {
            PlayerPrefs.SetInt("highScore", currentScore);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 100, 20), "High Score: " + highScore, largeFont);
    }
    
}
