using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {

    [SerializeField]
    Material[] bloodMaterials;
    [SerializeField]
    Object bloodPrefab;
    GameObject[] bloodTransforms;
    private int lastBlood;

	// Use this for initialization
	void Start () {
        lastBlood = -1;
        bloodTransforms = new GameObject[200];
	    for(int i = 0; i < 200; i++)
        {
            GameObject tmpBlod = (GameObject)GameObject.Instantiate(bloodPrefab);
            tmpBlod.renderer.material = bloodMaterials[Random.Range(0, bloodMaterials.Length)];
            bloodTransforms[i] = tmpBlod;
        }
	}

    public void showNextBlood(Vector3 pos)
    {
        if(lastBlood < 199)
        {
            lastBlood = lastBlood + 1;
        }
        else
        {
            lastBlood = 0;
        }
        Color c = bloodTransforms[lastBlood].renderer.material.color;
        bloodTransforms[lastBlood].transform.position = pos;
        c.a = 1;
        bloodTransforms[lastBlood].renderer.material.color = c;
    }


	
}
