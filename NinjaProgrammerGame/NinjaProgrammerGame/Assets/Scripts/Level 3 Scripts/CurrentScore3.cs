using UnityEngine;
using System.Collections;

public class CurrentScore3 : MonoBehaviour {

    public GameObject player;
    private float distance;
    private int multiplier;
    private int currentScore3;
    private int highScore3;

    public GUIStyle largeFont;


    void Start()
    {
        this.multiplier = 10;
        this.currentScore3 = 0;

        largeFont = new GUIStyle();

        largeFont.fontSize = 32;
    }

    void Update()
    {
        this.distance = player.transform.position.x;
        this.currentScore3 = (int)distance * multiplier;

        if (currentScore3 > highScore3)
        {
            highScore3 = currentScore3;
        }
    }
    public void OnGUI()
    {
        GUI.Label(new Rect(10, 0, 100, 20), "Score:" + currentScore3, largeFont);

    }
}
