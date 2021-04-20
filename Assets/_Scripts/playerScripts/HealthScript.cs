using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;
    
    
    
    
    private playerAttack player_Anim;




    public float health = 100f;
    public bool is_Player, is_Enemy;
    private bool is_Dead;

    
    void Awake()
    {
        if (is_Enemy)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            //get enemy audio
        }   
        
        if (is_Player)
        {

        }
    }

    // Update is called once per frame
    public void ApplyDamage(float damage)
    {
        if (is_Dead)
        {
            return;
        }

        health -= damage;

        if (is_Player) //health UI
        {

        }

        if (is_Enemy) //health UI
        {
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
        
        
        
        
        player_Anim.death();




        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
