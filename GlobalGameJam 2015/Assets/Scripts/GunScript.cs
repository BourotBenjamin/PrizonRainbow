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
    private float fireLightTime = 0.03f;
    [SerializeField]
    private Light gunLight;
	ManetteController _ctrl;
    private BloodScript bloodScript;
    private LineRenderer lineRenderer;
    [SerializeField]
    private Texture playerTexture;
    [SerializeField]
    private GameObject playerQuad;



	void Start () 
	{
		_ctrl = GetComponent<ManetteController>();
        bloodScript = Camera.main.GetComponent<CameraScirpt>().bloodScript;
        lineRenderer = this.GetComponent<LineRenderer>();
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
                gunLight.enabled = true;
                RaycastHit hit;
                lineRenderer.SetVertexCount(2);
                if (Physics.Raycast(transform.position + transform.forward * 0.4f, transform.right, out hit, 100f))
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, hit.collider.transform.position);
                    if (hit.collider.tag == "mob")
                    {
                        Destroy(hit.collider.gameObject);
                        bloodScript.showNextBlood(hit.collider.transform.position);
                    }
                }
                else
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, transform.position + (transform.right * 10));
                }
                lineRenderer.enabled = true;
            }
        }
        else if(Time.timeSinceLevelLoad - fireTime > fireMinTime )
        {
            fire = false;
        }
        else if (Time.timeSinceLevelLoad - fireTime > fireLightTime)
        {
            gunLight.enabled = false;
            lineRenderer.enabled = false;
        }
	}
    public override int getWeaponId()
    {
        return 0;
    }
    public override void setAmmo(int ammo)
    {
        playerQuad.renderer.material.SetTexture(0, playerTexture);
        this.ammo = ammo;
    }
}
