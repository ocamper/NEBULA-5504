using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private bool doorOpen;

    [SerializeField] private ButtonStateStorage button;
    [SerializeField] private BulletTriggerButton altTrigger;

    private void Update()
    {
        if (button != null && altTrigger == null)
        {
            if (button.buttonActive)
                doorOpen = true;
            else
                doorOpen = false;
        }

        if (altTrigger != null && button == null)
        {
            if (altTrigger.triggerActive)
                doorOpen = true;
            else
                doorOpen = false;
        }

        if (altTrigger != null && button != null)
        {
            Debug.Log(button.buttonActive);

            if (altTrigger.triggerActive && button.buttonActive)
                doorOpen = true;
            else
                doorOpen = false;
        }


        if (doorOpen)
            doorAnim.SetBool("doorOpen", true);
        else
            doorAnim.SetBool("doorOpen", false);
    }

}
