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


    public int enemyHp = 100;

    private void Update()
    {
        Debug.Log(aiPath.desiredVelocity.x);

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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.LoseHealth(20);
        }
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Bullet"))
            enemyHp -= 34;
    }
}
