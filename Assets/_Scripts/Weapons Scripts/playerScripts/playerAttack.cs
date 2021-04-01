using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private weaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    void Awake() {
        weapon_Manager = GetComponent<weaponManager>();

    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        weaponShoot();
    }

    void weaponShoot() {
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE) {

            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire) {
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                //BulletFired();
            }

        } else {

            if (Input.GetMouseButtonDown(0)) {
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                //BulletFired();
            }

        }
    }
}
