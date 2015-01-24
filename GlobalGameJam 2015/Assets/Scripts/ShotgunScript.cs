using UnityEngine;
using System.Collections;

public class ShotgunScript : WeaponScript{

    [SerializeField]
    private Transform playerTransform;
    private bool fire = false;
    private bool fireButton = false;
    private float fireTime = 0;
    [SerializeField]
    private float fireMinTime = 1;
    [SerializeField]
    private float fireLightTime = 0.25f;
    [SerializeField]
    private Light light;
    [SerializeField]
    private BloodScript bloodScript;
	
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
                light.enabled = true;
                fireTime = Time.timeSinceLevelLoad;
                RaycastHit hit;
                Quaternion qt;
                for (int i = 0; i < 10; ++i )
                {
                    qt = Quaternion.AngleAxis(Random.Range(-15, 15), Vector3.forward);
                    if (Physics.Raycast(playerTransform.position, qt * playerTransform.right, out hit, 100f))
                    {
                        print(hit.collider.tag);
                        if (hit.collider.tag == "mob")
                        {
                            bloodScript.showNextBlood(hit.collider.transform.position);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                }
            }
        }
        else
        {
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
    public override int getWeaponId()
    {
        print("shotgun");
        return 1;
    }
}
