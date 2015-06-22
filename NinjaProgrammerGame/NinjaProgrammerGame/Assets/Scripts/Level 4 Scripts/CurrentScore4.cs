using UnityEngine;
using System.Collections;

public class CurrentScore4 : MonoBehaviour
{

    public GameObject player;
    private float distance;
    private int multiplier;
    private int currentScore4;
    private int highScore4;

    public GUIStyle largeFont;


    void Start()
    {
        this.multiplier = 10;
        this.currentScore4 = 0;

        largeFont = new GUIStyle();

        largeFont.fontSize = 32;
        largeFont.normal.textColor = Color.red;
    }

    void Update()
    {
        this.distance = player.transform.position.x;
        this.currentScore4 = (int)distance * multiplier;

        if (currentScore4 > highScore4)
        {
            highScore4 = currentScore4;
        }
    }
    public void OnGUI()
    {
        GUI.Label(new Rect(10, 0, 100, 20), "Score:" + currentScore4, largeFont);

    }
}
