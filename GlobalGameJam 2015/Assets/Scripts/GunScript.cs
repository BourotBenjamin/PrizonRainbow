using UnityEngine;
using System.Collections;

public class GunScript : WeaponScript{

    // Use this for initialization
    private bool fire = false;
    private bool fireButton = false;
    private float fireTime = 0;
    [SerializeField]
    private float fireMinTime = 1;
    [SerializeField]
    private float fireLightTime = 0.25f;
    [SerializeField]
    private Light light;
    private Transform playerTransform;
    private BloodScript bloodScript;

	void Start () {
        playerTransform = this.transform;
        bloodScript = Camera.main.GetComponent<CameraScirpt>().bloodScript;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            fireButton = true;
        }
        if (Input.GetButtonUp("Fire"))
        {
            fireButton = false;
        }
	    if(!fire)
        {
            if(ammo > 0 && fireButton)
            {
                --ammo;
                fire = true;
                fireTime = Time.timeSinceLevelLoad;
                light.enabled = true;
                RaycastHit hit;
                if (Physics.Raycast(playerTransform.position, playerTransform.right, out hit, 100f))
                {
                    print(hit.collider.tag);
                    if (hit.collider.tag == "mob")
                    {
                        Destroy(hit.collider.gameObject);
                        bloodScript.showNextBlood(hit.collider.transform.position);
                    }
                }
            }
        }
        else if(Time.timeSinceLevelLoad - fireTime > fireMinTime )
        {
            fire = false;
        }
        else if (Time.timeSinceLevelLoad - fireTime > fireLightTime)
        {
            light.enabled = false;
        }
	}
    public override int getWeaponId()
    {
        print("gun");
        return 0;
    }
}
