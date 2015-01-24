using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

    [SerializeField]
    private bool keyNeeded;

    void Start()
    {
        
    }

	// Use this for initialization
	void OnTriggerEnter (Collider col) 
    {
        if (!keyNeeded || (col.GetComponent<KeyScript>().hasKey()))
        {
            Destroy(this.gameObject);
        }
	}
}
