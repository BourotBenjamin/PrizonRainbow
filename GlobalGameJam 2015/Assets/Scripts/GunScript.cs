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
	[SerializeField]
	private AudioClip _gunShot;
	[SerializeField]
	private AudioClip[] _goreSounds;


	ManetteController _ctrl;    
    private BloodScript bloodScript;



	void Start () 
	{
		_ctrl = GetComponent<ManetteController>();        
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
            if(ammo > 0 && (fireButton || _ctrl.firebtn))
            {
                --ammo;
                fire = true;
                fireTime = Time.timeSinceLevelLoad;
				audio.PlayOneShot(_gunShot);
                light.enabled = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.right, out hit, 100f))
                {
                    print(hit.collider.tag);
                    if (hit.collider.tag == "mob")
                    {
						hit.collider.gameObject.audio.PlayOneShot(_goreSounds[Mathf.FloorToInt(Random.Range(0f, _goreSounds.Length-0.01f))]);
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
