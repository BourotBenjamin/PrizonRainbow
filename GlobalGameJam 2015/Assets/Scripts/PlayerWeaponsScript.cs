using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeaponsScript : MonoBehaviour {

    private WeaponScript[] scripts;
	
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
                print("Script " + i + " enabled");
                weaponScript.enabled = true;
                weaponScript.setAmmo(ammoValue);
            }
            else
            {
                print("Script " + i + " disaled");
                weaponScript.enabled = false;
                weaponScript.setAmmo(ammoValue);
            }
            ++i;
        }
	}
}
