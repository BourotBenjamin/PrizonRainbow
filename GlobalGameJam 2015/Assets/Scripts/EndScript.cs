using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

    public GameStopScript game;

	// Use this for initialization
	void Start () {
        game = Camera.main.GetComponent<GameStopScript>();
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "player")
        {
            game.ended = true;
        }
    }

    void OnGUI()
    {
        if(game.ended)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), "What do we do now ?");
        }
    }
}
