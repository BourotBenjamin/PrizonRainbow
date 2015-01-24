using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    protected int ammo = 0;

    public void setAmmo(int ammo)
    {
        this.ammo = ammo;
    }
}
