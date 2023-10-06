using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public WeaponSO thisGun; 
    public GameObject bulletPrefab;
    public Transform firePoint;
    private int bulletsFired = 0;
    private bool isFiring = false;

    void Start()
    {
        StartCoroutine(FireBurst());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFiring)
        {
            StartCoroutine(FireBurst());
        }
    }
    IEnumerator FireBurst()
    {
        isFiring = true;
        bulletsFired = 0;

        while (bulletsFired < thisGun.baseAmmo)
        {
            FireBullet();
            bulletsFired++;
            yield return new WaitForSeconds(thisGun.fireRate);
        }

        yield return new WaitForSeconds(thisGun.reloadSpeed); // Chờ 1 giây trước khi cho phép bắn tiếp
        isFiring = false;
    }

    void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Kiểm tra và đánh dấu viên đạn cần xóa sau một khoảng thời gian
        BulletController bulletController = newBullet.GetComponent<BulletController>();
        if (bulletController != null)
        {
            bulletController.damage = thisGun.baseDamage;
            bulletController.shouldDestroy = true;
        }
    }
}
