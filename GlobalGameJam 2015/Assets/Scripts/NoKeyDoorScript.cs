using UnityEngine;
using System.Collections;

public class NoKeyDoorScript : MonoBehaviour {

	void OnTriggerEnter (Collider col) 
	{
		if (col.gameObject.tag == "player")
		{
			Camera.main.GetComponent<CameraScirpt>().PlayDoor();
			Destroy(this.gameObject, 0.2f);
		}
	}
}
