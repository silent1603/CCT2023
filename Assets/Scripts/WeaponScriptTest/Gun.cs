using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private Targeting _targeting;

    public WeaponSO thisGun; 
    public BulletController bulletPrefab;
    public Transform spawnPoint;

    [Header("Ammo")]
    public int curAmmo;
    public bool infiniteAmmo = false;
    public float damage = 2;

    [Header("Weapon Attributes")]
    int _damage;
    int _ammo;
    float _bulletSpeed;
    float _reloadSpeed;
    float _fireRate;
    public LayerMask detectionLayer;
    public Transform bulletSpawnPoint;

    public bool canFire = true;
    public bool outOfAmmo = false;

    void Start()
    {
        _targeting = GetComponentInParent<Targeting>();

        _damage = thisGun.baseDamage;
        _bulletSpeed = thisGun.bulletSpeed;
        _reloadSpeed = thisGun.reloadSpeed;
        _ammo = thisGun.baseAmmo;
        _fireRate = thisGun.fireRate;

        //StartCoroutine(FireBurst());
    }

    // Update is called once per frame
    void Update()
    {
        //if (_targeting.priorityTarget == null) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("............");
            ShootWeapon();
        }
    }

    public void ShootWeapon()
    {
        canFire = false;

        Vector3 pos = bulletSpawnPoint.position;
        curAmmo--;
        //UpdateUI();

        BulletController go = Instantiate(bulletPrefab, pos, spawnPoint.transform.rotation);
        go.damage = _damage;
        var rb = go.GetComponent<Rigidbody>();

        rb.velocity = this.transform.right * _bulletSpeed;
    }

    public IEnumerator FireRate()
    {
        while (!outOfAmmo)
        {
            ShootWeapon();
            float timeToNextFire = 1 / (_fireRate / 60);
            yield return new WaitForSeconds(timeToNextFire);
        }

    }

    public void ReloadSystem()
    {
        if (curAmmo == _ammo) return;

        if (infiniteAmmo)
        {
            curAmmo = _ammo;

            outOfAmmo = false;
            //UpdateUI();
            return;
        }

        outOfAmmo = false;
        //UpdateUI();
    }

    //public void UpdateUI()
    //{
    //    weaponName_txt.text = weaponData.WeaponName;

    //    if (weaponData.WeaponSprite != null)
    //    {
    //        weaponImage.sprite = weaponData.WeaponSprite;
    //    }
    //    else
    //    {
    //        weaponImage.sprite = null;
    //    }

    //    curAmmo_txt.text = curAmmo.ToString();

    //    if (infiniteAmmo)
    //        reserveAmmo_txt.text = "Inifinite";
    //    else
    //        reserveAmmo_txt.text = "/ " + reserveAmmo.ToString();
    //}
}
