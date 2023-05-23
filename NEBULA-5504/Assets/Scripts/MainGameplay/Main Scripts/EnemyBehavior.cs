using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour
{
    public AIPath aiPath;
    [SerializeField] PlayerMovement player;
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GameObject deathFx;

    private float redValue = 255f;

    public int enemyHp = 100;

    private void Awake()
    {
        deathFx = Resources.Load<GameObject>("Prefabs/bloodEffect");
    }

    private void Update()
    {
        spriteRenderer.color = new Color(255f, redValue, redValue);


        if (aiPath.desiredVelocity.x < 0f)
        {
            spriteRenderer.flipX = false;
            enemyAnim.SetBool("isMoving", true);
        }
        else if (aiPath.desiredVelocity.x > 0f)
        {
            spriteRenderer.flipX = true;
            enemyAnim.SetBool("isMoving", true);
        }
        
        if (aiPath.desiredVelocity.x == 0)
        {
            enemyAnim.SetBool("isMoving", false);
        }

        if (enemyHp <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathFx, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.LoseHealth(20);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Bullet"))
        {
            enemyHp -= 34;
            StartCoroutine(ColorChange());
        }
    }

    IEnumerator ColorChange()
    {
        redValue = 0f;

        for (int i = 0; i < 10; i++)
        {
            redValue = i;
            yield return new WaitForSecondsRealtime(0.1f);
        }   
    }
}
