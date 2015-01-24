using UnityEngine;
using System.Collections;

public class ShotgunAmmoScript : MonoBehaviour {

    public bool active;

    void Start()
    {
        this.active = false;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        if (active)
        {
            if (collider.tag == "mob")
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
