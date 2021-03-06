﻿using UnityEngine;
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

    // Use this for initialization
    void Start()
    {
        playerOne = Camera.main.GetComponent<CameraScirpt>().playerOne.collider;
        playerTwo = Camera.main.GetComponent<CameraScirpt>().playerTwo.collider;
        playerOneKeyScript = playerOne.GetComponent<KeyScript>();
        playerTwoKeyScript = playerTwo.GetComponent<KeyScript>();
    }


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
