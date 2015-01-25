using UnityEngine;
using System.Collections;

public class BloodUpdateScript : MonoBehaviour {

    public GameStopScript game;

    // Use this for initialization
    void Start()
    {
        game = Camera.main.GetComponent<GameStopScript>();
    }
	// Update is called once per frame
	void Update () 
    {
	    if(!game.ended && this.renderer.material.color.a>0)
        {
            Color c = this.renderer.material.color;
            c.a -= Time.deltaTime / 10;
            if(c.a<0)
            {
                c.a = 0;
            }
            this.renderer.material.color = c;
        }
	}
}
