using UnityEngine;
using System.Collections;

public class CameraScirpt : MonoBehaviour {

    public Transform playerOne;
    public Transform playerTwo;
    public BloodScript bloodScript;

    private Transform cameraTransform;

	[SerializeField]
	private AudioClip _doorSound;
    private GameStopScript game;

    // Use this for initialization
    void Start()
    {
        game = Camera.main.GetComponent<GameStopScript>();
        cameraTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (!game.ended)
        {
            if (playerTwo != null && playerTwo.gameObject.activeSelf && playerOne != null && playerOne.gameObject.activeSelf)
            {
                Vector3 dist = playerTwo.position - playerOne.position;
                cameraTransform.position = playerOne.position + (dist / 2) + Vector3.back * 4;
                cameraTransform.camera.orthographicSize = Mathf.Max(6, dist.magnitude);
            }
            else if (playerTwo != null && playerTwo.gameObject.activeSelf)
            {
                cameraTransform.position = playerTwo.position + Vector3.back * 4;
                cameraTransform.camera.orthographicSize = 6;
            }
            else if (playerOne != null && playerOne.gameObject.activeSelf)
            {
                cameraTransform.position = playerOne.position + Vector3.back * 4;
                cameraTransform.camera.orthographicSize = 6;
            }
        }
	}

	public void PlayDoor()
	{
		audio.PlayOneShot(_doorSound);
	}

}
