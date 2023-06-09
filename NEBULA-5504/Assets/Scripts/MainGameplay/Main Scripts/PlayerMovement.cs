using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    public bool MovementAvailable = true;

    private Vector2 movement;
    private Vector2 rawMovement;

    private static bool hpIncreaseOn;
    public int health;
    public HealthBarScript hpBar;

    public static bool ActionAvailable = true;

    public static bool teleportAvailable = true;

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private GameObject hurtFx;

    private bool takeDamage = true;

    private void Awake()
    {
        health = 100;
        hpBar.SetHealth(health);
    }

    void Update()
    {


        if (Time.timeScale == 0) return;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical"); //Store direction input values as the Player's Vector2 Axis

        rawMovement.x = Input.GetAxisRaw("Horizontal");
        rawMovement.y = Input.GetAxisRaw("Vertical");

        if (health <= 0)
        {
            ActionAvailable = false;
            MovementAvailable = false;

          //  currentScene = SceneManager.GetActiveScene().buildIndex;
          //  SceneManager.LoadScene("11DeathScene");
        }

        if (MovementAvailable)
        {
            if (rawMovement.x != 0 || rawMovement.y != 0)
                anim.SetBool("isWalking", true);
            else
                anim.SetBool("isWalking", false);
        }

        
        if (rawMovement.x > 0 && MovementAvailable)
        {
            playerSprite.flipX = true;
        } else if (rawMovement.x < 0 && MovementAvailable)
        {
            playerSprite.flipX = false;
        }


        if (health < 100)
        {
            if (!hpIncreaseOn)
                StartCoroutine(hpIncrease());
        }

    }

    void FixedUpdate()
    {

        if (MovementAvailable)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Constantly moves the Player to its current position PLUS the directional input values from the Vector2 variable, multiplied by the set speed and by the fixedDeltaTime to avoid framerate discrepancies between machines
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
            LoseHealth(30);
    }

    public void LoseHealth(int hpDecrease)
    {
        if (takeDamage)
        {
            StartCoroutine(hpLoss());
            health -= hpDecrease;
        }
       
        hpBar.SetHealth(health);
    }

    IEnumerator hpIncrease()
    {
        hpIncreaseOn = true;

        for(int i = health; i < 100; i++)
        {
            health++;
            hpBar.SetHealth(health);

            if (i >= 99)
                hpIncreaseOn = false;

            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator hpLoss()
    {
        hurtFx.SetActive(true);
        takeDamage = false;
        yield return new WaitForSeconds(1);
        takeDamage = true;
    }
    
    // Teleport availability below ugh i hate organizing code

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TeleportTriggers")
        {
            teleportAvailable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TeleportTriggers")
        {
            teleportAvailable = true;
        }
    }
}
