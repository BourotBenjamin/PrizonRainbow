using UnityEngine;
using System.Collections;

public abstract class WeaponScript : MonoBehaviour {

    protected int ammo = 0;

    public void setAmmo(int ammo)
    {
        this.ammo = ammo;
    }
    public int getAmmo()
    {
        return ammo;
    }

    public abstract int getWeaponId();
}
