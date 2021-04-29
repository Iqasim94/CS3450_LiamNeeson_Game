using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    public GameObject enemy_Prefab, NPC_Prefab, Key_Prefab;

    public int enemy_Count;

    public Transform[] enemy_SpawnPoints;
    public Transform[] NPC_SpawnPoints;


    void Awake()
    {
        MakeInstance();    
    }

    void Start()
    {
        enemy_Count = PlayerPrefs.GetInt("Num_Enemies");
        SpawnEnemies();
        SpawnNPC();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void SpawnEnemies()
    {
        int index = enemy_Count;

        for (int i = 0; i < enemy_SpawnPoints.Length-1; i++)
        {
            if (index == 0)
            {
                break;
            }

            Instantiate(enemy_Prefab, enemy_SpawnPoints[i].position, Quaternion.identity);
            index--;
        }

        for (int i = 0; i < index; i++)
        {
            if (index == 0)
            {
                break;
            }

            Instantiate(enemy_Prefab, enemy_SpawnPoints[Random.Range(0, enemy_SpawnPoints.Length - 1)].position, Quaternion.identity);
            index--;
        }
    }

    void SpawnNPC()
    {
        int NPC = Random.Range(0, NPC_SpawnPoints.Length - 1);
        int Key = Random.Range(0, NPC_SpawnPoints.Length - 1);

        while (Key == NPC)
        {
            Key = Random.Range(0, NPC_SpawnPoints.Length - 1);
        }

        Instantiate(NPC_Prefab, NPC_SpawnPoints[NPC].position, Quaternion.identity);
        Instantiate(Key_Prefab, NPC_SpawnPoints[Key].position, Quaternion.identity);
    }

    public void enemyDeath()
    {
        enemy_Count -= 1;
    }
}
