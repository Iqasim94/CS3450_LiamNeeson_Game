using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private weaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;
    private Camera mainCam;
    private GameObject crosshair;

    void Awake()
    {
        weapon_Manager = GetComponent<weaponManager>();
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
        mainCam = Camera.main;
    } //Awake()

    // Update is called once per frame
    void Update() 
    {
        weaponShoot();
        ZoomInAndOut();
    } //Update()

    void weaponShoot() 
    {
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE) {

            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire) {
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                BulletFired();
            }

        } else {

            if (Input.GetMouseButtonDown(0)) {
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                BulletFired();
            }

        }
    } //weaponShoot()

    void ZoomInAndOut()
    {
        if (Input.GetMouseButtonDown(1))
        {
            zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
            crosshair.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
            crosshair.SetActive(true);
        }

    } //ZoomInAndOut

    void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            if (hit.transform.tag == Tags.ENEMY_TAG)
            {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }  
        }
    } //bulletFired
}
