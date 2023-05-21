using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerButton : MonoBehaviour
{
    public bool triggerActive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            triggerActive = true;
            GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
        }
    }
}
