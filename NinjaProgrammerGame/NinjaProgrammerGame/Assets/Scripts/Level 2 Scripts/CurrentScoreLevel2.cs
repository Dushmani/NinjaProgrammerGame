using UnityEngine;
using System.Collections;

public class CurrentScoreLevel2 : MonoBehaviour {

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

        largeFont = new GUIStyle();

        largeFont.fontSize = 32;
    }

    void Update()
    {
        this.distance = player.transform.position.x;
        this.currentScore2 = (int)distance * multiplier;

        if (currentScore2 > highScore2)
        {
            highScore2 = currentScore2;
        }
    }
    public void OnGUI()
    {
        GUI.Label(new Rect(10, 0, 100, 20), "Score:" + currentScore2, largeFont);

    }
}
