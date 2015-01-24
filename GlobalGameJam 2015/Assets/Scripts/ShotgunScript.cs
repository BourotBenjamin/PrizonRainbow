using UnityEngine;
using System.Collections;

public class ShotgunScript : WeaponScript{

    [SerializeField]
    private ShotgunAmmoScript ammoScript;
    private bool fire = false;
    private bool fireButton = false;
    private float fireTime = 0;
    [SerializeField]
    private float fireMinTime = 1;
    [SerializeField]
    private float fireLightTime = 0.25f;
    [SerializeField]
    private Light light;

	// Use this for initialization
	void Start () {
        ammoScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Fire"))
        {
            fireButton = true;
        }
        if (Input.GetButtonUp("Fire"))
        {
            fireButton = false;
        }
        if (!fire)
        {
            if (ammo > 0 && fireButton)
            {
                --ammo;
                fire = true;
                ammoScript.active = true;
                print("RunAmmo");
                light.enabled = true;
                fireTime = Time.timeSinceLevelLoad;
            }
        }
        else
        {
            ammoScript.active = false;
            if (Time.timeSinceLevelLoad - fireTime > fireMinTime)
            {
                fire = false;
            }
            else if (Time.timeSinceLevelLoad - fireTime > fireLightTime)
            {
                light.enabled = false;
            }
        }
	}
}
