using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

    private bool key = false;
	[SerializeField]
	private AudioClip _getKey; 

    public void grabKey()
    {
        key = true;
		Camera.main.audio.PlayOneShot(_getKey);
    }
    public bool hasKey()
    {
        return key;
    }

}
