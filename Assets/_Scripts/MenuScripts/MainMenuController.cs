using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void ButtonHandlerPlay ()
	{
		PlayerPrefs.SetInt("HighScore", 0);
		SceneManager.LoadScene(1);
	}

	public void ButtonHandlerLoad()
	{
		SceneManager.LoadScene(1);
		GetComponent<ScoreScript>().LoadGame();
	}

	public void ButtonHandlerQuit ()
	{
		Application.Quit();
	}
}
