using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void ButtonHandlerPlay ()
	{
		PlayerPrefs.SetInt("HighScore", 0);
		PlayerPrefs.SetInt("Level", 1);
		PlayerPrefs.SetInt("Num_Enemies", 12);
		PlayerPrefs.SetFloat("EnemyHealth", 100f);
		PlayerPrefs.SetFloat("EnemyDamage", 2f);

		SceneManager.LoadScene(1);
	}

	public void ButtonHandlerLoad()
	{
		SceneManager.LoadScene(1);
	}

	public void ButtonHandlerQuit ()
	{
		Application.Quit();
	}
}
