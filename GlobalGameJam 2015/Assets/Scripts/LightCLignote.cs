using UnityEngine;
using System.Collections;

public class LightCLignote : MonoBehaviour {

	private Light2D Mylight;
	bool WhichColor;

	void Start()
	{
		Mylight = GetComponent<Light2D>();
	}
	// Update is called once per frame
	void Update () {
		Mylight.LightColor = Color.Lerp(Color.black,Color.red,Mathf.Abs( Mathf.Sin(Time.time*3f)));
		Color TROLOLO = Mylight.LightColor;
		TROLOLO.a = 0;
		Mylight.LightColor = TROLOLO;
	}
}
