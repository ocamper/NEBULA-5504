using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private bool doorOpen;

    [SerializeField] private ButtonScript trigger;

    private void Update()
    {

        if (trigger.buttonActive)
            doorOpen = true;
        else
            doorOpen = false;

        if (doorOpen)
            doorAnim.SetBool("doorOpen", true);
        else
            doorAnim.SetBool("doorOpen", false);
    }

}
