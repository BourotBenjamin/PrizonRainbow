using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class ManetteController : MonoBehaviour {

	public float speed = 6;
	public GameObject _FlashlightUp;
	public GameObject _FlashlightDown;
	public GameObject _orientation;
	public int _index; // numéro du joueur
	public bool lightIsOn;
	public bool firebtn;

	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;
	
	// Use this for initialization
	void Start () 
	{
		_FlashlightUp.SetActive(false);
		_FlashlightDown.SetActive(false);
		lightIsOn = false;
		firebtn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerIndex testPlayerIndex = (PlayerIndex)_index;
		GamePadState testState = GamePad.GetState(testPlayerIndex);
		if (testState.IsConnected)
		{
			//Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
			playerIndex = testPlayerIndex;
		}


		prevState = state;
		state = GamePad.GetState(playerIndex);
		
		// Detect if a button was pressed this frame
		if (state.Buttons.RightShoulder == ButtonState.Pressed)
		{
			//Shoot
		}
		// Detect if a button was released this frame
		if (state.Buttons.LeftShoulder == ButtonState.Pressed && prevState.Buttons.LeftShoulder == ButtonState.Released)
		{
			_FlashlightUp.SetActive(true);
			_FlashlightDown.SetActive(true);
			lightIsOn = true;
		}
		if (state.Buttons.LeftShoulder == ButtonState.Released && prevState.Buttons.LeftShoulder == ButtonState.Pressed )
		{
			_FlashlightUp.SetActive(false);
			_FlashlightDown.SetActive(false);
			lightIsOn = false;
		}
		if (state.Buttons.RightShoulder == ButtonState.Pressed && prevState.Buttons.RightShoulder == ButtonState.Released)
		{
			firebtn = true;
		}
		if (state.Buttons.RightShoulder == ButtonState.Released && prevState.Buttons.RightShoulder == ButtonState.Pressed )
		{
			firebtn = false;
		}


		// Set vibration according to triggers
		GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
		
		// Make the current object turn	
		Move();
		Watch ();

	}
		
	void onCollisionEnter(Collider other)
	{
		if(other.tag == "Joueur")
		{
			other.gameObject.SetActive(false);
		}
	}


	void Move()
	{
		float translationV = state.ThumbSticks.Left.Y * speed;
		float translationH = state.ThumbSticks.Left.X * speed;
		translationH *= Time.deltaTime;
		translationV *= Time.deltaTime;
		transform.Translate(translationH, translationV, 0, Space.World);
	}
	
	void Watch()
	{
		Vector3 pozycja = new Vector3(transform.position.x + state.ThumbSticks.Right.X,transform.position.y + state.ThumbSticks.Right.Y, transform.position.z);  
		if(Mathf.Abs(state.ThumbSticks.Right.X) > 0.3f || Mathf.Abs(state.ThumbSticks.Right.Y) > 0.3f)
		{
			_orientation.transform.position = pozycja;
			float AngleRad = Mathf.Atan2(_orientation.transform.position.y - transform.position.y, _orientation.transform.position.x - transform.position.x); 
			float AngleDeg = (180 / Mathf.PI) * AngleRad; 
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, AngleDeg), Time.deltaTime*10);
		}
	}
	
}
