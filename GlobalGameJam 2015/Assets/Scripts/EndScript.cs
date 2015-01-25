﻿using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

    private GameStopScript game;
    [SerializeField]
    private GameObject zombieEmpty;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;

	// Use this for initialization
	void Start () {
        game = Camera.main.GetComponent<GameStopScript>();
        for(int i = 0; i< 30; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                GameObject.Instantiate(zombieEmpty, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
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