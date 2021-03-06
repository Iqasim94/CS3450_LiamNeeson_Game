using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    [SerializeField]
    private weaponHandler[] weapons;

    private int current_Weapon_Index;

    // Start is called before the first frame update
    void Start()
    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //Use Scroll Wheel to switch weapon
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (current_Weapon_Index < 2)
            {
                TurnOnSelectedWeapon(current_Weapon_Index + 1);
            }
            else
            {
                TurnOnSelectedWeapon(0);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (current_Weapon_Index > 0)
            {
                TurnOnSelectedWeapon(current_Weapon_Index - 1);
            }
            else
            {
                TurnOnSelectedWeapon(2);
            }

        }

        //Use num keys to swtich weapons
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { 
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { 
            TurnOnSelectedWeapon(2);
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (current_Weapon_Index == weaponIndex) {
            return;
        }

        weapons[current_Weapon_Index].gameObject.SetActive(false);
        weapons[weaponIndex].gameObject.SetActive(true);
        current_Weapon_Index = weaponIndex;
    }

    public weaponHandler GetCurrentSelectedWeapon() {
        return weapons[current_Weapon_Index];
    }

}
