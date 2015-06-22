using UnityEngine;
using System.Collections;

public class HighScoreLevel2 : MonoBehaviour {

    public GameObject player;
    private float distance;
    private int multiplier;
    private int currentScore2;
    private int highScore2;

    public GUIStyle largeFont;


    void Start()
    {
        this.multiplier = 10;
        this.currentScore2 = 0;
        this.highScore2 = PlayerPrefs.GetInt("highScore2");

        largeFont = new GUIStyle();

        largeFont.fontSize = 32;
    }

    void Update()
    {

        this.distance = player.transform.position.x;
        this.currentScore2 = (int)distance * multiplier;

        if (currentScore2 > highScore2)
        {
            PlayerPrefs.SetInt("highScore2", currentScore2);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 100, 20), "High Score: " + highScore2, largeFont);
    }
}
