using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip die_Clip, attack_Clip, detect_Clip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play_DetectSound() //When enemy attacks
    {
        audioSource.clip = detect_Clip;
        audioSource.Play();
    }

    public void Play_AttackSound() //When enemy attacks
    {
        audioSource.clip = attack_Clip;
        audioSource.Play();
    }

    public void Play_DeadSound() //When enemy dies
    {
        audioSource.clip = die_Clip;
        audioSource.Play();
    }
}
