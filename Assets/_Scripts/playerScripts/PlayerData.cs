using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//Class to format all the data we need to save
[System.Serializable]
public class PlayerData
{
    //public int level;
    public float health;
    public float[] position;
//    public int score;

    public PlayerData(Data player)
    {
        health = player.health;

        position = new float[3];
        position[0] = player.posX;
        position[1] = player.posY;
        position[2] = player.posZ;

//        score = player.score;
    }
}
