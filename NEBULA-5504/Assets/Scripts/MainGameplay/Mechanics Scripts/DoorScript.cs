using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private bool doorOpen;

    //   [SerializeField] private ButtonStateStorage button;
    //  [SerializeField] private BulletTriggerButton altTrigger;

    [SerializeField] private ButtonStateStorage[] directButtonTriggers;
    [SerializeField] private ButtonStateStorage[] inverseButtonTriggers;

    [SerializeField] private BulletTriggerButton[] directBtTriggers;

    private bool check1;
    private bool check2;
    private bool check3;

    private int dircheck1;
    private int dircheck2;
    private int dircheck3;

    private void Update()
    {
        //    if (button != null && altTrigger == null)
        //    {
        //        if (button.buttonActive)
        //            doorOpen = true;
        //        else
        //            doorOpen = false;
        //    }
        //
        //    if (altTrigger != null && button == null)
        //    {
        //        if (altTrigger.triggerActive)
        //            doorOpen = true;
        //        else
        //            doorOpen = false;
        //    }
        //
        //    if (altTrigger != null && button != null)
        //    {
        //        Debug.Log(button.buttonActive);
        //
        //        if (altTrigger.triggerActive && button.buttonActive)
        //            doorOpen = true;
        //        else
        //            doorOpen = false;
        //    }


        


        if (directButtonTriggers.Length == 0) { check1 = true; }
        else
        {
            dircheck1 = 0;
            foreach(ButtonStateStorage button in directButtonTriggers)
            {
                if (button.buttonActive)
                    dircheck1++;

                if (dircheck1 == directButtonTriggers.Length)
                    check1 = true;
                else
                    check1 = false;
            }
        }

        if (inverseButtonTriggers.Length == 0) { check2 = true; }
        else
        {
            dircheck2 = 0;
            foreach (ButtonStateStorage button in inverseButtonTriggers)
            {
                if (!button.buttonActive)
                    dircheck2++;

                if (dircheck2 == inverseButtonTriggers.Length)
                    check2 = true;
                else
                    check2 = false;
            }
        }

        if (directBtTriggers.Length == 0) { check3 = true; }
        else
        {
            dircheck3 = 0;
            foreach (BulletTriggerButton trigger in directBtTriggers)
            {
                if (trigger.triggerActive)
                    dircheck3++;

                if (dircheck3 == directBtTriggers.Length)
                    check3 = true;
                else
                    check3 = false;
            }
        }


        if (check1 && check2 && check3)
            doorOpen = true;
        else
            doorOpen = false;


      //  Debug.Log(check1);
     //  Debug.Log(check2);
      //  Debug.Log(check3);





        if (doorOpen)
            doorAnim.SetBool("doorOpen", true);
        else
            doorAnim.SetBool("doorOpen", false);
    }

}
