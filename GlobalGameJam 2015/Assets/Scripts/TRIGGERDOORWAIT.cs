using UnityEngine;
using System.Collections;

public class TRIGGERDOORWAIT : MonoBehaviour {
	public AudioSource ALARM;
	public GameObject DoorDelete;
	public GameObject light;


	void OnTriggerEnter()
	{
		ALARM.PlayOneShot(ALARM.clip);
		Invoke("DeleteDoor", 10f);
		light.SetActive (true);
	}
	void DeleteDoor()
	{
		DoorDelete.SetActive(false);
	}
}
