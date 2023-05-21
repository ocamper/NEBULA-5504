using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce;

    [SerializeField] private HealthBarScript reloadBar;

    private int cooldown;
    private bool bulletReady = true;
    
    private GameObject bulletPrefab;

    private void Awake()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && PlayerMovement.ActionAvailable && bulletReady)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            bulletReady = false;
            StartCoroutine(BulletCooldown());
        }

        if (bulletReady)
            reloadBar.gameObject.SetActive(false);
        else
            reloadBar.gameObject.SetActive(true);
    }

    IEnumerator BulletCooldown()
    {

        reloadBar.SetHealth(0);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.12f);

            reloadBar.SetHealth(i);

            if (i >= 9)
                bulletReady = true;
        }
    }
}
