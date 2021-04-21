using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    private MainCameraAnimator player_Death;
    public GameObject gameOver;

    void Awake()
    {
        player_Death = GetComponent<MainCameraAnimator>();
        gameOver = GetComponent<GameObject>();
    }

    void Update()
    {
        if (gameOver.activeSelf)
        {
            RunDeathAnim();
        }

/*        if ((GetComponent<HealthScript>().is_Player) && (GetComponent<HealthScript>().is_Dead))
        {
            RunDeathAnim();
        }
*/    }

    public void RunDeathAnim()
    {
        player_Death.Dead(true);
    }
}
