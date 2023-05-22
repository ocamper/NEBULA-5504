using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    private GameObject breakFx;

    private void Start()
    {
        breakFx = Resources.Load<GameObject>("Prefabs/bulletBreakEffect");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Laser")
            DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("enemySprite"))
            DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
        Instantiate(breakFx, transform.position, transform.rotation);
    }
}
