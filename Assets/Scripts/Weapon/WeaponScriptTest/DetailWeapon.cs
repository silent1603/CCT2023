using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailWeapon : MonoBehaviour
{
    public void changeWeapon(WeaponSO newWeapon)
    {
        GameObject.Find("NameWeapon").GetComponent<TextMeshProUGUI>().text = "" + newWeapon.weaponType;
        GameObject.Find("DamageValue").GetComponent<TextMeshProUGUI>().text = "" + newWeapon.baseDamage;
        GameObject.Find("ProjectilesValue").GetComponent<TextMeshProUGUI>().text = "" + newWeapon.bulletPerShot;
        GameObject.Find("ReloadTimeValue").GetComponent<TextMeshProUGUI>().text = "" + newWeapon.reloadSpeed;
        GameObject.Find("FireRateValue").GetComponent<TextMeshProUGUI>().text = "" +  1 / newWeapon.fireRate;
        GameObject.Find("MaxAmmoValue").GetComponent<TextMeshProUGUI>().text = "" + newWeapon.baseAmmo;
        
    }
}
