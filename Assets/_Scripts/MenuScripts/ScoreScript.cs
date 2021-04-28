using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public Text scoreText;
    public Text levelText;
//    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //GetComponent - cast highscore from load file to score var.
        scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //scoreText.text = score.ToString();

        levelText.text = "Level: " + PlayerPrefs.GetInt("Level").ToString();
    }

    public void AddPoints(int points)
    {
        //        score += points;
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore") + points);
        scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
//        scoreText.text = score.ToString();
    }
}
