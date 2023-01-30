using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeArma : MonoBehaviour
{
    public GameObject[] weapons;
    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
            int previusWeapon = selectedWeapon;
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                selectedWeapon = NextWeapon();
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                selectedWeapon = PreviusWeapon();
            }

            WeaponNumeric();

            if (previusWeapon != selectedWeapon)
            {
                SelectWeapon();

            }
        
    }

    private void WeaponNumeric()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

    }

        private int PreviusWeapon()
    {
        if (selectedWeapon <= 0) //si estamos en el primero volvemos a la ultima que es 0
        {
            return weapons.Length - 1;
        }
        else
        {
            return --selectedWeapon;
        }


    }

    private int NextWeapon()
    {
        if (selectedWeapon >= 1) //si estamos en la ultima volvemos a la primera que es 0
        {
            return 0;
        }
        else
        {
            return ++selectedWeapon; // si no le suma uno
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in weapons)
        {

                if (i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
            
            i++;
        }

      
    }
}
