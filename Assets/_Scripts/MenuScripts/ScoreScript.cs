using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public Text scoreText;
    public int score = 0; 

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void AddPoints(int points)
    {
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore") + points);
        scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore"));
    }
}
