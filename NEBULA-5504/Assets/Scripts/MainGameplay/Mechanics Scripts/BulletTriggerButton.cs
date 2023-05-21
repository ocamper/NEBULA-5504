using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerButton : MonoBehaviour
{
    public bool triggerActive;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite activeSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            triggerActive = true;
            spriteRenderer.sprite = activeSprite;
        }
    }
}
