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



    private void Awake()
    {
        health = 100;
        hpBar.SetHealth(health);
    }

    void Update()
    {

        Debug.Log(hpIncreaseOn);

        if (Time.timeScale == 0) return;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical"); //Store direction input values as the Player's Vector2 Axis

        rawMovement.x = Input.GetAxisRaw("Horizontal");
        rawMovement.y = Input.GetAxisRaw("Vertical");


        if (health <= 0)
        {
          //  currentScene = SceneManager.GetActiveScene().buildIndex;
          //  SceneManager.LoadScene("11DeathScene");
        }

        //     if (rawMovement.x != 0 || rawMovement.y != 0)
        //         playerAnim.SetBool("isWalking", true);
        //    else
        //        playerAnim.SetBool("isWalking", false);

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

    public void LoseHealth(int hpDecrease)
    {
        health -= hpDecrease;
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

}
