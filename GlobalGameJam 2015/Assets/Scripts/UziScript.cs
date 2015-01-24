﻿using UnityEngine;
using System.Collections;

public class UziScript : WeaponScript {

    private bool fire = false;
    private bool fireButton = false;
    private float fireTime = 0;
    [SerializeField]
    private float fireMinTime = 0.1f;
    [SerializeField]
    private float fireLightTime = 0.03f;
    [SerializeField]
    private Light light;
    private BloodScript bloodScript;
    private LineRenderer lineRenderer;
    ManetteController _ctrl;


    void Start()
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
        if (!fire)
        {
            if (ammo > 0 && (fireButton || _ctrl.firebtn))
            {
                --ammo;
                fire = true;
                light.enabled = true;
                fireTime = Time.timeSinceLevelLoad;
                RaycastHit hit;
                Quaternion qt;
                lineRenderer.SetVertexCount(2);
                qt = Quaternion.AngleAxis(Random.Range(-5, 5), Vector3.forward);
                Debug.DrawRay(transform.position, qt * transform.right, Color.green, 15);
                if (Physics.Raycast(transform.position, qt * transform.right, out hit, 100f))
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, hit.collider.transform.position);
                    if (hit.collider.tag == "mob")
                    {
                        bloodScript.showNextBlood(hit.collider.transform.position);
                        Destroy(hit.collider.gameObject);
                    }
                }
                else
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, transform.position + (qt * transform.right * 10));
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
        return 2;
    }
}