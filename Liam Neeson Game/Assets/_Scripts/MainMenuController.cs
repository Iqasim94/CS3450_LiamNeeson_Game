using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void ButtonHandlerPlay ()
	{
		SceneManager.LoadScene(1);
	}

/*	public void ButtonHandlerLoad()
	{
		Load feature
	}
*/
	public void ButtonHandlerQuit ()
	{
		Application.Quit();
	}


}
