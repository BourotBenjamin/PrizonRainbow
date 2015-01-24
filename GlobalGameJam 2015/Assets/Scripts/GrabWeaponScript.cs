using UnityEngine;
using System.Collections;

public class GrabWeaponScript : MonoBehaviour {

    private Transform playerOne;
    private Transform playerTwo;
    [SerializeField]
    private int idWeapon = 1;
    [SerializeField]
    private int ammoValue = 1;
    private PlayerWeaponsScript playerOneWeaponScript;
    private PlayerWeaponsScript playerTwoWeaponScript;
    private bool playerOneInTrigger;
    private bool playerTwoInTrigger;
    
    void Start()
    {
        playerOne = Camera.main.GetComponent<CameraScirpt>().playerOne;
        playerTwo = Camera.main.GetComponent<CameraScirpt>().playerTwo;
        playerOneWeaponScript = playerOne.GetComponent<PlayerWeaponsScript>();
        playerTwoWeaponScript = playerTwo.GetComponent<PlayerWeaponsScript>();
    }

	// Use this for initialization
	void Update ()
    {
        if (playerOneInTrigger)
        {
            int nextWeapon = idWeapon;
            int nextAmmo = ammoValue;
            if (Input.GetButtonDown("P1_grabAmmo"))
            {
                int weapon = playerOneWeaponScript.getCurrentWeapon();
                if(weapon != -1)
                {
                    int ammo = playerOneWeaponScript.getCurrentAmmo();
                    if(ammo > 0)
                    {
                        this.idWeapon = weapon;
                        this.ammoValue = ammo;
                    }
                    else
                    {
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
                playerOneWeaponScript.SetScriptEnabled(nextWeapon, nextAmmo);
            }
        }
        if (playerTwoInTrigger)
        {
            int nextWeapon = idWeapon;
            int nextAmmo = ammoValue;
            if (Input.GetButtonDown("P2_grabAmmo"))
            {
                int weapon = playerTwoWeaponScript.getCurrentWeapon();
                if (weapon != -1)
                {
                    int ammo = playerTwoWeaponScript.getCurrentAmmo();
                    if (ammo > 0)
                    {
                        this.idWeapon = weapon;
                        this.ammoValue = ammo;
                    }
                    else
                    {
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
                playerTwoWeaponScript.SetScriptEnabled(nextWeapon, nextAmmo);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col == playerOne.collider)
        {
            playerOneInTrigger = true;
            print("P2In");
        }
        if (col == playerTwo.collider)
        {
            playerTwoInTrigger = true;
            print("P1In");
        }
    }
    // Update is called once per frame
    void OnTriggerExit(Collider col)
    {
        if (col == playerOne.collider)
        {
            playerOneInTrigger = false;
            print("P1Out");
        }
        if (col == playerTwo.collider)
        {
            playerTwoInTrigger = false;
            print("P2Out");
        }
    }
}
