using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//Class for centralizing all the data for saving
public class Data : MonoBehaviour
{
    public float health = 100f;
    public float posX = 25.01f;
    public float posY = -3f;
    public float posZ = 38.776f;
    public int score = 0;
    //level
    //enemy numbers
    //enemy locations


    public void Start()
    {
        health = GetComponent<HealthScript>().health;

        posX = GetComponent<FirstPersonController>().transform.position.x;
        posY = GetComponent<FirstPersonController>().transform.position.y;
        posZ = GetComponent<FirstPersonController>().transform.position.z;

        score = ScoreScript.instance.score;
    }

    public void SavePlayer()
    {
        health = GetComponent<HealthScript>().health;

        posX = GetComponent<FirstPersonController>().transform.position.x;
        posY = GetComponent<FirstPersonController>().transform.position.y;
        posZ = GetComponent<FirstPersonController>().transform.position.z;

        score = ScoreScript.instance.score;

        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        score = data.score;
    }
}
