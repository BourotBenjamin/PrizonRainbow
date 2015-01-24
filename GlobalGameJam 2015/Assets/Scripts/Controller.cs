using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed = 1;
	public GameObject _FlashlightUp;
	public GameObject _FlashlightDown;

	// Use this for initialization
	void Start () 
	{
		_FlashlightUp.SetActive(false);
		_FlashlightDown.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
		Watch ();
	
		if(Input.GetMouseButtonDown(1))
		{
			_FlashlightUp.SetActive(true);
			_FlashlightDown.SetActive(true);
		}
		if(Input.GetMouseButtonUp(1))
		{
			_FlashlightUp.SetActive(false);
			_FlashlightDown.SetActive(false);
		}	
	
	
	}

	void Move()
	{
		float translationV = Input.GetAxis("Vertical") * speed;
		float translationH = Input.GetAxis("Horizontal") * speed;
		translationH *= Time.deltaTime;
		translationV *= Time.deltaTime;
		transform.Translate(translationH, translationV, 0, Space.World);
	}

	void Watch()
	{
		Vector3 pozycja = Camera.main.ScreenToWorldPoint (Input.mousePosition); 
		float AngleRad = Mathf.Atan2(pozycja.y - transform.position.y, pozycja.x - transform.position.x); 
		float AngleDeg = (180 / Mathf.PI) * AngleRad; 
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}

}
