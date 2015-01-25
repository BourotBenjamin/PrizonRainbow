﻿using UnityEngine;
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
    private Light gunLight;
    private BloodScript bloodScript;
	[SerializeField]
	private AudioClip _shotgunShot;
	[SerializeField]
    private AudioClip[] _bigGoreSounds;
    [SerializeField]
    private Texture playerTexture;
    [SerializeField]
    private GameObject playerQuad;


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
                gunLight.enabled = true;
				audio.PlayOneShot(_shotgunShot);
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
                        if (hit.collider.tag == "mob")
                        {
							hit.collider.gameObject.audio.PlayOneShot(_bigGoreSounds[Mathf.FloorToInt(Random.Range(0f, _bigGoreSounds.Length-0.01f))]);
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
                gunLight.enabled = false;
                lineRenderer.enabled = false;
                lineRenderer.SetVertexCount(0);
            }
        }
	}
    public override int getWeaponId()
    {
        return 1;
    }
    public override void setAmmo(int ammo)
    {
        playerQuad.renderer.material.SetTexture(0, playerTexture);
        this.ammo = ammo;
    }
}
