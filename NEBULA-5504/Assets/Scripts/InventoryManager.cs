using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static int objectHeld;

    public static void objectChange(int obj)
    {
        objectHeld = obj;
    }
}
