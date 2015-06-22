using UnityEngine;
using System.Collections;

public class ReturnToMenuScript : MonoBehaviour {

    public void PlayButtonClick()
    {
        Application.LoadLevel("Menu");
        Debug.Log("mai iskat da igraqt");

    }
}
