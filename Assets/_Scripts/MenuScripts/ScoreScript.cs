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
    public Text gameOverScore;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        gameOverScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        levelText.text = "Level: " + PlayerPrefs.GetInt("Level").ToString();
    }

    public void AddPoints(int points)
    {
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore") + points);
        scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        gameOverScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
