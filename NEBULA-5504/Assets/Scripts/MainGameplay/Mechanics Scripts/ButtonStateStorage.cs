using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStateStorage : MonoBehaviour
{
    [SerializeField] ButtonScript scriptToStore;

    private int localState;
    public bool buttonActive;

    private void Update()
    {
        if (scriptToStore.gameObject.activeSelf)
        {
            localState = scriptToStore.activeState;
        }

        if (localState > 0)
        {
            if (!scriptToStore.gameObject.activeSelf)
            {
                if (localState == 1 || localState == 3)
                {
                    buttonActive = true;
                }
                else
                {
                    buttonActive = false;
                }
            }
        }
        else
        {
            buttonActive = false;
        }
    }
}
