using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {

    [SerializeField]
    Material[] bloodMaterials;
    [SerializeField]
    Object bloodPrefab;

    public void showNextBlood(Vector3 pos)
    {
        GameObject tmpBlod = (GameObject)GameObject.Instantiate(bloodPrefab);
        tmpBlod.renderer.material = bloodMaterials[Random.Range(0, bloodMaterials.Length)];
        tmpBlod.transform.position = pos;
    }


	
}
