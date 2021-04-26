using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public Text scoreText;
    public int score = 0;
    private Transform player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadGame();
        scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void AddPoints(int points)
    {
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore") + points);
        scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void LoadGame()
    {
        //get player
        player = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
        //assign player coordinates
        player.transform.position = new Vector3(
            PlayerPrefs.GetFloat("PlayerPositionX"), 
            PlayerPrefs.GetFloat("PlayerPositionY"), 
            PlayerPrefs.GetFloat("PlayerPositionZ"));
        //assign player rotation
        player.transform.rotation = Quaternion.Euler(0, 
            PlayerPrefs.GetFloat("PlayerLookX"), 
            PlayerPrefs.GetFloat("PlayerLookY"));
        //
    }
}
