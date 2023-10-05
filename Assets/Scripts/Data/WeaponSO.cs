///Phap Nguyen
///Description:
///Created date: 04/10/2023
///Last edit: 05/10/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Pistol, Shotgun, SMG, Rifle}

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "New Data/New Weapon Data")]
public class WeaponSO : ScriptableObject
{

    //TODO:
    public WeaponType weaponType;
    public float fireRate;
    public float bulletSpeed;
    public int baseAmmo;
    public float reloadSpeed;
    public int bulletPerShot;
    public float bulletSpreadCone;


}
