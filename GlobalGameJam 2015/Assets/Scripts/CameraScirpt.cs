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
        if (playerTwo.gameObject.activeSelf && playerOne.gameObject.activeSelf)
        {
            Vector3 dist = playerTwo.position - playerOne.position;
            cameraTransform.position = playerOne.position + (dist / 2) + Vector3.back * 4;
            cameraTransform.camera.orthographicSize = Mathf.Max(6, dist.magnitude);
        }
        else if (playerTwo.gameObject.activeSelf)
        {
            cameraTransform.position = playerTwo.position;
            cameraTransform.camera.orthographicSize = 6;
        }
        else if (playerOne.gameObject.activeSelf)
        {
            cameraTransform.position = playerOne.position;
            cameraTransform.camera.orthographicSize = 6;
        }
	}

}
