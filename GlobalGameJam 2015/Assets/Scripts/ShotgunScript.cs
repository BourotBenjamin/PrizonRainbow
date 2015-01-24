using UnityEngine;
using System.Collections;

public class ShotgunScript : WeaponScript{


    private bool fire = false;
    private bool fireButton = false;
    private float fireTime = 0;
    [SerializeField]
    private float fireMinTime = 1;
    [SerializeField]
    private float fireLightTime = 0.03f;
    [SerializeField]
    private Light light;
    [SerializeField]
    private BloodScript bloodScript;
    private LineRenderer lineRenderer;
	ManetteController _ctrl;
	
	
	void Start () 
	{
		_ctrl = GetComponent<ManetteController>();
        bloodScript = Camera.main.GetComponent<CameraScirpt>().bloodScript;
        lineRenderer = this.GetComponent<LineRenderer>();
    }

	// Update is called once per frame
	void Update () {
        print(ammo);
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
                lineRenderer.SetVertexCount(20);
                for (int i = 0; i < 10; ++i )
                {
                    qt = Quaternion.AngleAxis(Random.Range(-15, 15), Vector3.forward);
                    if (Physics.Raycast(transform.position, qt * transform.right, out hit, 100f))
                    {
                        lineRenderer.SetPosition((i * 2) + 0, transform.position);
                        lineRenderer.SetPosition((i * 2) + 1, hit.collider.transform.position);
                        print(hit.collider.tag);
                        if (hit.collider.tag == "mob")
                        {
                            bloodScript.showNextBlood(hit.collider.transform.position);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else
                    {
                        lineRenderer.SetPosition((i * 2) + 0, transform.position);
                        lineRenderer.SetPosition((i * 2) + 1, transform.position + (qt * transform.right * 10));
                    }
                }
                lineRenderer.enabled = true;
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
                lineRenderer.enabled = false;
                lineRenderer.SetVertexCount(0);
            }
        }
	}
    public override int getWeaponId()
    {
        print("shotgun");
        return 1;
    }
}
