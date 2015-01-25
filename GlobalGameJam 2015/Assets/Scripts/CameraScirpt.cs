using UnityEngine;
using System.Collections;

public class CameraScirpt : MonoBehaviour {

    public Transform playerOne;
    public Transform playerTwo;
    public BloodScript bloodScript;
    public GameObject zombie;

    private Transform cameraTransform;
    public GameStopScript game;
	[SerializeField]
	private AudioClip _doorSound;
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
            if (playerTwo.gameObject.activeSelf && playerOne.gameObject.activeSelf)
            {
                Vector3 dist = playerTwo.position - playerOne.position;
                cameraTransform.position = playerOne.position + (dist / 2) + Vector3.back * 4;
                cameraTransform.camera.orthographicSize = Mathf.Max(6, dist.magnitude);
            }
            else if (playerTwo.gameObject.activeSelf)
            {
                cameraTransform.position = playerTwo.position + Vector3.back * 4;
                cameraTransform.camera.orthographicSize = 6;
            }
            else if (playerOne.gameObject.activeSelf)
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
