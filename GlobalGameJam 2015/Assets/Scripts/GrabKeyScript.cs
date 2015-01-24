using UnityEngine;
using System.Collections;

public class GrabKeyScript : MonoBehaviour {

    [SerializeField]
    private Collider playerOne;
    [SerializeField]
    private Collider playerTwo;
    [SerializeField]
    private KeyScript playerOneKeyScript;
    [SerializeField]
    private KeyScript playerTwoKeyScript;


    void OnTriggerEnter(Collider col)
    {
        if (col == playerOne)
        {
            playerOneKeyScript.grabKey();
            Destroy(this.gameObject);
        }
        if (col == playerTwo)
        {
            playerTwoKeyScript.grabKey();
            Destroy(this.gameObject);
        }
    }
}
