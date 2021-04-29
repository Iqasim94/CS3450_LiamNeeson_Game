using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float PlayerHealth;
    public float EnemyHealth;
    public bool is_Player, is_Enemy;
    public bool is_Dead;

    private EnemyAudio enemyAudio;
    private PlayerStats player_Stats;
    private EnemyStats enemy_Stats;


    void Awake()
    {
        if (is_Enemy)
        {
            EnemyHealth = PlayerPrefs.GetFloat("EnemyHealth");
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

        if (is_Player) //health UI
        {
            PlayerHealth -= damage;
            player_Stats.Display_HealthStats(PlayerHealth);
        }

        if (is_Enemy) //health UI
        {
            EnemyHealth -= damage;
            enemy_Stats.Display_HealthStats(EnemyHealth);

            if (enemy_Controller.Enemy_State == EnemyState.PATROL)
            {
                enemy_Controller.chase_Distance = 50f;
            }
        }

        if (PlayerHealth <= 0f || EnemyHealth <= 0f)
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

            EnemyManager.instance.enemyDeath();
            ScoreScript.instance.AddPoints(10);
        }

        if (is_Player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            GetComponent<FirstPersonController>().enabled = false;
            GetComponent<playerAttack>().enabled = false;
            GetComponent<weaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("TurnOffGameObject", 5f);
        }

        if (EnemyManager.instance.enemy_Count == 0)
        {
            Invoke("NextLevel", 5f);
        }
    }

    void TurnOffGameObject ()
    {
        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.Play_DeadSound();
    }

    void NextLevel ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        PlayerPrefs.SetInt("Num_Enemies", PlayerPrefs.GetInt("Num_Enemies") + 2);
        PlayerPrefs.SetFloat("EnemyHealth", PlayerPrefs.GetFloat("EnemyHealth") + 20f);
        PlayerPrefs.SetFloat("EnemyDamage", PlayerPrefs.GetFloat("EnemyDamage") + 2f);
    }
}
