using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject enemy_Prefab;

    public Transform[] enemy_SpawnPoints;

    [SerializeField]
    private int enemy_Count;


    void Awake()
    {
        MakeInstance();    
    }

    void Start()
    {
        SpawnEnemies();
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
            Instantiate(enemy_Prefab, enemy_SpawnPoints[i].position, Quaternion.identity);
            index--;
        }

        for (int i = 0; i < index; i++)
        {
            Instantiate(enemy_Prefab, enemy_SpawnPoints[Random.Range(0, enemy_SpawnPoints.Length - 1)].position, Quaternion.identity);
            index--;
        }

        enemy_Count = 0;
    }
}
