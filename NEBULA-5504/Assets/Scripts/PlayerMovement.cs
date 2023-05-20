using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    public bool MovementAvailable = true;
    public int health;

    private Vector2 movement;
    private Vector2 rawMovement;
    private Vector2 mousePos;


    public static bool ActionAvailable = true;



    private void Awake()
    {
        health = 100;

        if (positionHandler.preTpPosition == null) { Debug.Log("bye bye"); return; }

        transform.position = positionHandler.preTpPosition;
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
          //  currentScene = SceneManager.GetActiveScene().buildIndex;
          //  SceneManager.LoadScene("11DeathScene");
        }

        //     if (rawMovement.x != 0 || rawMovement.y != 0)
        //         playerAnim.SetBool("isWalking", true);
        //    else
        //        playerAnim.SetBool("isWalking", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            positionHandler.SceneChange(transform);
        }

    }

    void FixedUpdate()
    {

        if (MovementAvailable)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Constantly moves the Player to its current position PLUS the directional input values from the Vector2 variable, multiplied by the set speed and by the fixedDeltaTime to avoid framerate discrepancies between machines
        }

    }

}
