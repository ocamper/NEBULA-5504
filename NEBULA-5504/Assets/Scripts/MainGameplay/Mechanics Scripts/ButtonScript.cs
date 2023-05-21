using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int activeState;

    public bool playerIn;
    public bool boxIn;
    // [SerializeField] private AudioSource pressSfx;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }

        if (collision.gameObject.tag == "Box")
        {
            boxIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIn = false;
        }

        if (collision.gameObject.tag == "Box")
        {
            boxIn = false;
        }
    }

    private void CallActive(int type)
    {
        activeState = type;

        if (type > 0)
            spriteRenderer.sprite = sprites[0];
        else
            spriteRenderer.sprite = sprites[1];
    }

    private void Update()
    {

        switch (playerIn, boxIn)
        {
            case (false, false):
                CallActive(0);
                break;
            case (false, true):
                CallActive(1);
                break;
            case (true, false):
                CallActive(2);
                break;
            case (true, true):
                CallActive(3);
                break;
        }

       // if (buttonActive)
      //      anim.SetBool("isPressed", true);
       // else
      //      anim.SetBool("isPressed", false);
    }

    public void PressSfx()
    {
      //  pressSfx.Play();
    }
}
