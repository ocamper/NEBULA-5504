using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxBehavior : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float grabDistance;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null) return;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, player.position) < grabDistance)
        {
            if (InventoryManager.objectHeld == 0)
            {
                InventoryManager.objectChange(1);
                Destroy(transform.parent.gameObject);
            }
        }

        

    }
}
