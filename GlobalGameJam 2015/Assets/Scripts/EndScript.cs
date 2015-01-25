using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

    private GameStopScript game;
    [SerializeField]
    private GameObject zombieEmpty;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float sizeX;
    [SerializeField]
    private float sizeY;

	// Use this for initialization
	void Start () {
        game = Camera.main.GetComponent<GameStopScript>();
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                GameObject.Instantiate(zombieEmpty, new Vector3(x+i, y+j, 0), Quaternion.identity);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "player")
        {
            game.ended = true;
            Application.LoadLevel("endScene");
        }
    }

}
