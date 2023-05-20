using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static int objectHeld;
    [SerializeField] private GameObject boxUI;

    public static void objectChange(int obj)
    {
        objectHeld = obj;
    }

    private void Update()
    {
        if (boxUI == null) return;

        if (objectHeld == 1)
            boxUI.SetActive(true);

        if (objectHeld == 0)
            boxUI.SetActive(false);
    }
}
