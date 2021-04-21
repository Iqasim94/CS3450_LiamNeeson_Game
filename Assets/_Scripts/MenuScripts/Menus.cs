using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject FPSController;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        FPSController.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        FPSController.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
    }

    public void ButtonHandlerResume()
    {
        ResumeGame();
    }

    /*	public void ButtonHandlerSave()
        {
            Save feature
        }
    */
    public void ButtonHandlerQuit()
    {
        SceneManager.LoadScene(0);
    }
}
