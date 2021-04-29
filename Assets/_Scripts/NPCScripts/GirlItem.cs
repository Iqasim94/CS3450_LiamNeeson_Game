using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlItem : MonoBehaviour
{
    public GameObject key_Prefab;

    void Start()
    {
        key_Prefab = GameObject.FindGameObjectWithTag("NPC Key");
    }

    void OnTriggerEnter(Collider collider)
    {
        if ( (collider.gameObject.tag == "Player") &&
            (!key_Prefab.activeSelf) )
        {
            ScoreScript.instance.AddPoints(100);
            GameOver.instance.TurnOnLevelComplete();

            collider.enabled = false;
            Invoke("NextLevel", 5f);
        }
    }

    void NextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        PlayerPrefs.SetInt("Num_Enemies", PlayerPrefs.GetInt("Num_Enemies") + 2);
        PlayerPrefs.SetFloat("EnemyHealth", PlayerPrefs.GetFloat("EnemyHealth") + 20f);
        PlayerPrefs.SetFloat("EnemyDamage", PlayerPrefs.GetFloat("EnemyDamage") + 2f);
    }
}
