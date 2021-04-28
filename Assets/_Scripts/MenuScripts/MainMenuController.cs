﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void ButtonHandlerPlay ()
	{
		PlayerPrefs.SetInt("HighScore", 0);
		PlayerPrefs.SetInt("Level", 1);
		SceneManager.LoadScene(1);
	}

	public void ButtonHandlerLoad()
	{
//		GetComponent<Data>().LoadPlayer();
		SceneManager.LoadScene(1);
	}

	public void ButtonHandlerQuit ()
	{
		Application.Quit();
	}
}
