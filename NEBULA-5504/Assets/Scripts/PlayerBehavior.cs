using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private GameObject boxPrefab;

    private void Awake()
    {
        boxPrefab = Resources.Load<GameObject>("Prefabs/BoxPrefab");
    }

    private void Update()
    {
        if (InventoryManager.objectHeld == 1 && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(boxPrefab, firePoint.position, Quaternion.identity);
            InventoryManager.objectChange(0);
        }
    }
}
