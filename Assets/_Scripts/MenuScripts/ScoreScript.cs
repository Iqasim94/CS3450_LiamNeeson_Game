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

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
}
