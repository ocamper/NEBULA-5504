using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour
{
    public AIPath aiPath;
    [SerializeField] PlayerMovement player;

    public int enemyHp = 100;

    private void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (aiPath.desiredVelocity.x >= 0.01f)
            transform.localScale = new Vector3(1f, 1f, 1f);

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
