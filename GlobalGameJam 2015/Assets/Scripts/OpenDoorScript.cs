using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

    [SerializeField]
    private bool keyNeeded;
	[SerializeField]
	private AudioClip _useKey; 
	[SerializeField]
	private AudioClip _metalDoor; 

	// Use this for initialization
	void OnTriggerEnter (Collider col) 
    {
        if (!keyNeeded || (col.GetComponent<KeyScript>().hasKey()))
        {
			Camera.main.audio.PlayOneShot(_useKey);
            Destroy(this.gameObject, 0.2f);
        }
	}
	void OnDestroy() {
		Camera.main.audio.PlayOneShot(_metalDoor);
	}

}
