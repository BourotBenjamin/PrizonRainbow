using UnityEngine;
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
    private GameObject gunLight;
    private BloodScript bloodScript;
    private LineRenderer lineRenderer;
    ManetteController _ctrl;
    [SerializeField]
    private Texture playerTexture;
    [SerializeField]
    private GameObject playerQuad;
    private GameStopScript game;
	[SerializeField]
	private AudioClip _uziShot;
	[SerializeField]
	private AudioClip[] _goreSounds;
	
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
                    gunLight.SetActive(true);
                    fireTime = Time.timeSinceLevelLoad;
				    audio.PlayOneShot(_uziShot);
                    RaycastHit hit;
                    Quaternion qt;
                    lineRenderer.SetVertexCount(2);
                    qt = Quaternion.AngleAxis(Random.Range(-5, 5), Vector3.forward);
                    if (Physics.Raycast(transform.position + transform.forward * 0.4f, qt * transform.right, out hit, 100f))
                    {
                        lineRenderer.SetPosition(0, transform.position);
                        lineRenderer.SetPosition(1, hit.collider.transform.position);
                        if (hit.collider.tag == "mob")
                        {
                            bloodScript.showNextBlood(hit.collider.transform.position);
                            Destroy(hit.collider.gameObject);
                        }
                        bloodScript.showNextBlood(hit.collider.transform.position);
                        Destroy(hit.collider.gameObject);
						Camera.main.audio.PlayOneShot(_goreSounds[Random.Range(0, _goreSounds.Length)]);
						if (Random.Range(0, 10) >= 9)
						{
							audio.Play();
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
				    gunLight.SetActive(false);
				    lineRenderer.enabled = false;
                    lineRenderer.SetVertexCount(0);
                }
            }
        }
    }
    public override int getWeaponId()
    {
        return 2;
    }

    public override void setAmmo(int ammo)
    {
        playerQuad.renderer.material.SetTexture(0, playerTexture);
        this.ammo = ammo;
    }
}
