using UnityEngine;
using System.Collections;

public class BloodUpdateScript : MonoBehaviour {

    BloodScript bloodScript; 

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(this.renderer.material.color.a>0)
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

    public void setBloodScript(BloodScript script)
    {
        bloodScript = script;
    }
}
