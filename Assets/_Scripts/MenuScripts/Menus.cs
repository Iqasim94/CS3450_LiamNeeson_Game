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
    public GameObject crossHair;
    public playerAttack gunShot;

    // Start is called before the first frame update
    void Start()
    {
        gunShot = GetComponent<playerAttack>();
        pauseMenu.SetActive(false);
        crossHair.SetActive(true);
//        gunShot.SetActive(true);
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
        crossHair.SetActive(false);
//        gunShot.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        FPSController.GetComponent<FirstPersonController>().enabled = false;
        gunShot.GetComponent<playerAttack>().enabled = false;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        crossHair.SetActive(true);
//        gunShot.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        FPSController.GetComponent<FirstPersonController>().enabled = true;
        gunShot.GetComponent<playerAttack>().enabled = true;
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
