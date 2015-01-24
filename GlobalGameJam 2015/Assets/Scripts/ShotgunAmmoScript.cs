using UnityEngine;
using System.Collections;

public class ShotgunAmmoScript : MonoBehaviour {

	// Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
	    if(collider.tag == "player")
        {
            Destroy(collider.gameObject);
        }
	}
}
