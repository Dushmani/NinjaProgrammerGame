using UnityEngine;
using System.Collections;

public class HighScoreMenu : MonoBehaviour 
{

    private int highScore;
    GUIStyle largeFont;


   public void Start()
    {

        this.highScore = PlayerPrefs.GetInt("highScore")
                        + PlayerPrefs.GetInt("highScore2")
                        + PlayerPrefs.GetInt("highScore3")
                        + PlayerPrefs.GetInt("highScore4");
            ;
        PlayerPrefs.SetInt("TotalHighScore", highScore);

        largeFont = new GUIStyle();

        largeFont.fontSize = 48;
    }

    public void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(500, 200, 100, 100), "High Score: " + highScore, largeFont);
    }
}
