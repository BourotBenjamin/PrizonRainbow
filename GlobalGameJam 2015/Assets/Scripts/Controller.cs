using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed = 1;
	public GameObject _FlashlightUp;
	public GameObject _FlashlightDown;
    [SerializeField]
    private string verticalAxis;
    [SerializeField]
    private string horizontalAxis;
	public bool lightIsOn;

	float translationV;
	float translationH;
    
	// Use this for initialization
	void Start () 
	{
		_FlashlightUp.SetActive(false);
		_FlashlightDown.SetActive(false);
		lightIsOn = false;
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
			lightIsOn = true;
		}
		if(Input.GetMouseButtonUp(1))
		{
			_FlashlightUp.SetActive(false);
			_FlashlightDown.SetActive(false);
			lightIsOn = false;
		}	
	}
	void Move()
	{
        translationV = Input.GetAxis(verticalAxis) * speed;
        translationH = Input.GetAxis(horizontalAxis) * speed;
		//translationH *= Time.deltaTime;
		//translationV *= Time.deltaTime;
		//transform.Translate(translationH, translationV, 0, Space.World);
		rigidbody.velocity = new Vector3 (translationH, translationV, 0);
	}

	void Watch()
	{
		Vector3 pozycja = Camera.main.ScreenToWorldPoint (Input.mousePosition); 
		float AngleRad = Mathf.Atan2(pozycja.y - transform.position.y, pozycja.x - transform.position.x); 
		float AngleDeg = (180 / Mathf.PI) * AngleRad; 
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}

}
