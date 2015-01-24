using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

    [SerializeField]
    private bool keyNeeded;
    [SerializeField]
    private Collider playerOne;
    [SerializeField]
    private Collider playerTwo;
    [SerializeField]
    private KeyScript playerOneKey;
    [SerializeField]
    private KeyScript playerTwoKey;

	// Use this for initialization
	void OnTriggerEnter (Collider col) 
    {
        if(!keyNeeded || (col == playerOne && playerOneKey.hasKey()) || (col == playerOne && playerOneKey.hasKey()))
        {
            Destroy(this.gameObject);
        }
	}
}
