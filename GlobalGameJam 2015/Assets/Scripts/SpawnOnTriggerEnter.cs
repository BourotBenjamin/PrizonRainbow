using UnityEngine;
using System.Collections;

public class SpawnOnTriggerEnter : MonoBehaviour {
	public GameObject MobContainer;

	// Update is called once per frame
	void OnTriggerEnter () {
		gameObject.SetActive(false);
		MobContainer.SetActive(true);

	}
}
