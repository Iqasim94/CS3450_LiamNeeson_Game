using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponFireType
{
    SINGLE,
    MULTIPLE
}

public class weaponHandler : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shootSound, reloadSound;

    public WeaponFireType fireType;


    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    void Turn_On_MuzzleFlash() {
        muzzleFlash.SetActive(true);
    }

    void Turn_Off_MuzzleFlash() {
        muzzleFlash.SetActive(false);
    }

    void Play_ShootSound() {
        shootSound.Play();
    }

    void Play_ReloadSound()
    {
        reloadSound.Play();
    }
}
