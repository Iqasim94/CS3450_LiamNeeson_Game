using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject levelCompleted;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        levelCompleted.SetActive(false);
    }

    void Update()
    {
        if ((GetComponent<HealthScript>().is_Player) && (GetComponent<HealthScript>().is_Dead))
        {
            TurnOnGameOver();
        }

        if (EnemyManager.instance.enemy_Count == 0)
        {
            TurnOnLevelComplete();
        }
    }

    public void TurnOnGameOver()
    {
        gameOver.SetActive(true);
    }

    public void TurnOnLevelComplete()
    {
        levelCompleted.SetActive(true);
    }
}
