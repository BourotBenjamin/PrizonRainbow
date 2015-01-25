using UnityEngine;
using System.Collections;

public abstract class WeaponScript : MonoBehaviour {

    protected int ammo = 0;

    public abstract void setAmmo(int ammo);

    public abstract int getWeaponId();
    public int getAmmo()
    {
        return ammo;
    }
}
