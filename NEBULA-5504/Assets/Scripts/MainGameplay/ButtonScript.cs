using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool buttonActive;
   // [SerializeField] private Animator anim;
   // [SerializeField] private AudioSource pressSfx;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            CallActive();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            buttonActive = false;
        }
    }

    private void CallActive()
    {
        buttonActive = true;
    }

    private void Update()
    {
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
