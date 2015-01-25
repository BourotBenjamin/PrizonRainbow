using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class LoadSceneScript : MonoBehaviour {

    int _index = 0;
    int _index_2 = 1;
    PlayerIndex playerIndex;
    GamePadState state;
    PlayerIndex playerIndex_2;
    GamePadState state_2;
    private bool enabled = true;
    [SerializeField]
    private string levelToLoad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        PlayerIndex testPlayerIndex = (PlayerIndex)_index;
        GamePadState testState = GamePad.GetState(testPlayerIndex);
        if (testState.IsConnected)
        {
            playerIndex = testPlayerIndex;
        }
        state = GamePad.GetState(playerIndex);

        PlayerIndex testPlayerIndex_2 = (PlayerIndex)_index_2;
        GamePadState testState_2 = GamePad.GetState(testPlayerIndex_2);
        if (testState_2.IsConnected)
        {
            playerIndex_2 = testPlayerIndex_2;
        }
        state_2 = GamePad.GetState(playerIndex_2);
        if (enabled && (state.Buttons.A == ButtonState.Pressed || state_2.Buttons.A == ButtonState.Pressed || Input.GetButtonDown("Fire")))
        {
            Application.LoadLevel(levelToLoad);
            enabled = false;
        }
	}
}
