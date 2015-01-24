using UnityEngine;
using System.Collections;

public class CameraScirpt : MonoBehaviour {

    public Transform playerOne;
    public Transform playerTwo;
    public BloodScript bloodScript;

    private Transform cameraTransform;


	// Use this for initialization
	void Start () {
        cameraTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dist = playerTwo.position - playerOne.position;
        cameraTransform.position = playerOne.position + (dist / 2) + Vector3.back * 4;
        cameraTransform.camera.orthographicSize = dist.magnitude;
	}
}
