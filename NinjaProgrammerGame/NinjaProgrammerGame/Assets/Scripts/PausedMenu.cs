﻿using UnityEngine;
using System.Collections;

//Партизан се за бой стяга
//мята пушката на рамо.
//Една сутрин писмо стига
//пише вътре два-три реда:
//- Сбогом, майко, татко
//сбогом, мила сестро,
//аз отивам във боя
//дa загина, дa умра! <3       

public class PausedMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused;

	void Start() {

		PauseUI.SetActive(false);

		}

	void Update() {

		if(Input.GetButtonDown("Pause")){

			paused = !paused;

	    }

    if(paused) {

			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}

		if(!paused) {

			PauseUI.SetActive(false);
			Time.timeScale = 1;

		}
	
	}

	public void Resume() {

		paused = false;

		}
	

	public void Restart() {

		Application.LoadLevel (Application.loadedLevel);

		}

	public void MainMenu() {

		Application.LoadLevel("Menu");

		}

	public void Quit() {

		Application.Quit (); 

	}
	                         
}
