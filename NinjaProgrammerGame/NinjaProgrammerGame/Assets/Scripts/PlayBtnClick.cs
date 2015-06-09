using UnityEngine;
using System.Collections;

public class PlayBtnClick : MonoBehaviour 
{
	public void PlayButtonClick()
	{
		Application.LoadLevel("Level 3");
		Debug.Log("mai iskat da igraqt");
	}
}
