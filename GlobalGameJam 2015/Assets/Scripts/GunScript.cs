using UnityEngine;
using System.Collections;

public class GunScript : WeaponScript
{

    // Use this for initialization
    private bool fire = false;
    private bool fireButton = false;
    private float fireTime = 0;
    [SerializeField]
    private float fireMinTime = 1;
    [SerializeField]
    private float fireLightTime = 0.03f;
    [SerializeField]
    private GameObject gunLight;
    ManetteController _ctrl;
    private BloodScript bloodScript;
    private LineRenderer lineRenderer;
    [SerializeField]
    private Texture playerTexture;
    [SerializeField]
    private GameObject playerQuad;
    [SerializeField]
    private AudioClip _gunShot;
    [SerializeField]
    private AudioClip[] _goreSounds;
    private GameStopScript game;

    // Use this for initialization
    void Start()
    {
        game = Camera.main.GetComponent<GameStopScript>();
        _ctrl = GetComponent<ManetteController>();
        bloodScript = Camera.main.GetComponent<CameraScirpt>().bloodScript;
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!game.ended)
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
                    fireTime = Time.timeSinceLevelLoad;
				    audio.PlayOneShot(_gunShot);
				    gunLight.SetActive(true);
                    RaycastHit hit;
                    lineRenderer.SetVertexCount(2);
                    if (Physics.Raycast(transform.position + transform.forward * 0.4f, transform.right, out hit, 100f))
                    { 
                        lineRenderer.SetPosition(0, transform.position);
                        lineRenderer.SetPosition(1, hit.collider.transform.position);
                        if (hit.collider.tag == "mob")
                        {
                            hit.collider.gameObject.audio.PlayOneShot(_goreSounds[Random.Range(0, _goreSounds.Length)]);
                            if (Random.Range(0, 10) > 9)
                            {
                                audio.Play();
                            }
                            Destroy(hit.collider.gameObject);
                            bloodScript.showNextBlood(hit.collider.transform.position);
                            Camera.main.audio.PlayOneShot(_goreSounds[Mathf.FloorToInt(Random.Range(0, 3))]);
                            if (Random.Range(0, 10) > 9)
                            {
                                audio.Play();
                            }
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
            else if (Time.timeSinceLevelLoad - fireTime > fireMinTime)
            {
                fire = false;
            }
            else if (Time.timeSinceLevelLoad - fireTime > fireLightTime)
            {
                gunLight.SetActive(false);
                lineRenderer.enabled = false;
            }
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
