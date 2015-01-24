using UnityEngine;
using System.Collections;

public class ShotgunScript : WeaponScript{

<<<<<<< HEAD
=======
    private Transform playerTransform;
>>>>>>> dc5e2c34c7769e85f362bd56b244cc92c7edfc6e
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
	
<<<<<<< HEAD
	ManetteController _ctrl;
	
	
	void Start () 
	{
		_ctrl = GetComponent<ManetteController>();
	}
=======
    void Start()
    {
        playerTransform = this.transform;
        bloodScript = Camera.main.GetComponent<CameraScirpt>().bloodScript;
    }
>>>>>>> dc5e2c34c7769e85f362bd56b244cc92c7edfc6e

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
			if (ammo > 0 && (fireButton || _ctrl.firebtn ))
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
                    if (Physics.Raycast(transform.position, qt * transform.right, out hit, 100f))
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
