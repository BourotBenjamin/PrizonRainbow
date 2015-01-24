using UnityEngine;
using System.Collections;

public class GrabWeaponScript : MonoBehaviour {

    [SerializeField]
    private Collider playerOne;
    [SerializeField]
    private Collider playerTwo;
    [SerializeField]
    private PlayerWeaponsScript playerOneWeaponScript;
    [SerializeField]
    private PlayerWeaponsScript playerTwoWeaponScript;
    [SerializeField]
    private int idWeapon = 1;
    private bool playerOneInTrigger;
    private bool playerTwoInTrigger;
    


	// Use this for initialization
	void Update ()
    {
        if (playerOneInTrigger)
        {
            if (Input.GetButtonDown("P1_grabAmmo"))
            {
                playerOneWeaponScript.SetScriptEnabled(idWeapon);
                this.renderer.material.color = Color.red;
            }
        }
        if (playerTwoInTrigger)
        {
            if (Input.GetButtonDown("P2_grabAmmo"))
            {
                playerTwoWeaponScript.SetScriptEnabled(idWeapon);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col == playerOne)
        {
            playerOneInTrigger = true;
        }
        if (col == playerTwo)
        {
            playerTwoInTrigger = true;
        }
    }
    // Update is called once per frame
    void OnTriggerExit(Collider col)
    {
        if (col == playerOne)
        {
            playerOneInTrigger = false;
        }
        if (col == playerTwo)
        {
            playerTwoInTrigger = false;
        }
    }
}
