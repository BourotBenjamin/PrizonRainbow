using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

    private bool key = false;

    public void grabKey()
    {
        key = true;
    }
    public bool hasKey()
    {
        return key;
    }

}
