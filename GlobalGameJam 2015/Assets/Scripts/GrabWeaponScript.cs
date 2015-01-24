using UnityEngine;
using System.Collections;
using XInputDotNetPure;

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
    [SerializeField]
    private int ammoValue = 1;
    private bool playerOneInTrigger;
    private bool playerTwoInTrigger;

	int _index = 0;
	int _index_2 = 1;

	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	PlayerIndex playerIndex_2;
	GamePadState state_2;
	GamePadState prevState_2;


	// Use this for initialization
	void Update ()
    {
		PlayerIndex testPlayerIndex = (PlayerIndex)_index;
		GamePadState testState = GamePad.GetState(testPlayerIndex);
		if (testState.IsConnected)
		{
			playerIndex = testPlayerIndex;
		}
		
		
		prevState = state;
		state = GamePad.GetState(playerIndex);

		PlayerIndex testPlayerIndex_2 = (PlayerIndex)_index_2;
		GamePadState testState_2 = GamePad.GetState(testPlayerIndex_2);
		if (testState_2.IsConnected)
		{
			playerIndex_2 = testPlayerIndex_2;
		}
		
		
		prevState_2 = state_2;
		state_2 = GamePad.GetState(playerIndex_2);


        if (playerOneInTrigger)
        {
            int nextWeapon = idWeapon;
            int nextAmmo = ammoValue;
			if (Input.GetButtonDown("P1_grabAmmo") || (state.Buttons.A == ButtonState.Pressed && prevState.Buttons.A == ButtonState.Released))
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
			if (Input.GetButtonDown("P2_grabAmmo") || (state_2.Buttons.A == ButtonState.Pressed && prevState_2.Buttons.A == ButtonState.Released  ))
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
        if (col == playerOne)
        {
            playerOneInTrigger = true;
            print("P2In");
        }
        if (col == playerTwo)
        {
            playerTwoInTrigger = true;
            print("P1In");
        }
    }
    // Update is called once per frame
    void OnTriggerExit(Collider col)
    {
        if (col == playerOne)
        {
            playerOneInTrigger = false;
            print("P1Out");
        }
        if (col == playerTwo)
        {
            playerTwoInTrigger = false;
            print("P2Out");
        }
    }
}
