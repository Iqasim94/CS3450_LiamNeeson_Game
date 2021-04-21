using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((GetComponent<HealthScript>().is_Player) && GetComponent<HealthScript>().is_Dead)
        {
            TurnOnGameOver();
        }
    }

    void TurnOnGameOver()
    {
        gameOver.SetActive(true);
    }
}
