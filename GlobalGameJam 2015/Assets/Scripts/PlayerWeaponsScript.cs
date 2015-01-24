using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeaponsScript : MonoBehaviour {

    private WeaponScript[] scripts;
    private WeaponScript currentWeapon;
    [SerializeField]
    private int idJoueur;
	
    void Start()
    {
        scripts = this.GetComponents<WeaponScript>();
        foreach(WeaponScript weaponScript in scripts)
        {
            weaponScript.enabled = false;
        }
    }

	// Update is called once per frame
    public void SetScriptEnabled(int scriptId, int ammoValue) 
    {
        int i = 0;
        foreach(WeaponScript weaponScript in scripts)
        {
            if (i == scriptId)
            {
                weaponScript.enabled = true;
                weaponScript.setAmmo(ammoValue);
                currentWeapon = weaponScript;
            }
            else
            {
                weaponScript.enabled = false;
            }
            ++i;
        }
	}

    public int getCurrentWeapon()
    {
        if (currentWeapon != null)
            return currentWeapon.getWeaponId();
        else
            return -1;
    }
    public int getCurrentAmmo()
    {
        if (currentWeapon != null)
            return currentWeapon.getAmmo();
        else
            return -1;
    }

    public void OnGUI()
    {
        if(currentWeapon != null)
        { 
            int ammo = currentWeapon.getAmmo();
            GUI.Label(new Rect(idJoueur*100+10, 10, 100, 100), "Ammo : " + ammo);
        }
    }

}
