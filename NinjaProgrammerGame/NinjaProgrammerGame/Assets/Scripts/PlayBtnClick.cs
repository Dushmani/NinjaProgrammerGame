using UnityEngine;
using System.Collections;

public class PlayBtnClick : MonoBehaviour 
{
	public void PlayButtonClick()
	{
		//Application.LoadLevel("Level 1"); //ako ne se opravi level 1 she go mahneme i she imame samo 3 niva, sry :@:@
		Application.LoadLevel("Level 2");
		Debug.Log("mai iskat da igraqt");
	}
}
