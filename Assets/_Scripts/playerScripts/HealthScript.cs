﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float health = 100f;
    public bool is_Player, is_Enemy;
    public bool is_Dead;

    private EnemyAudio enemyAudio;
    private PlayerStats player_Stats;
    private EnemyStats enemy_Stats;

//    private GameObject enemyHealth;

    void Awake()
    {
        if (is_Enemy)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();
            enemy_Stats = GetComponent<EnemyStats>();
            enemyAudio = GetComponentInChildren<EnemyAudio>();
        }   
        
        if (is_Player)
        {
            player_Stats = GetComponent<PlayerStats>();
        }
    }

    public void ApplyDamage(float damage)
    {
        if (is_Dead)
        {
            return;
        }

        health -= damage;

        if (is_Player) //health UI
        {
            player_Stats.Display_HealthStats(health);
        }

        if (is_Enemy) //health UI
        {
            enemy_Stats.Display_HealthStats(health);

            if (enemy_Controller.Enemy_State == EnemyState.PATROL)
            {
                enemy_Controller.chase_Distance = 50f;

            }
        }

        if (health <= 0f)
        {
            PlayerDied();
            is_Dead = true;
        }
    }

    void PlayerDied()
    {
        if (is_Enemy)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 50f);

            enemy_Controller.enabled = false;
            navAgent.enabled = false;
            enemy_Anim.enabled = false;

            // StartCoroutine
            StartCoroutine(DeadSound());

            //EnemyManager - spawn more enemies
        }

        if (is_Player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // Call enemy manager to stop spawning enemies

            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            GetComponent<playerAttack>().enabled = false;
            GetComponent<weaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("TurnOffGameObject", 5f);
        }
    }

    void TurnOffGameObject ()
    {        
        gameObject.SetActive(false);

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.Play_DeadSound();
        GameObject.FindWithTag(Tags.ENEMY_HEALTH).SetActive(false);
    }
}
