using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxBehavior : MonoBehaviour
{
    private Transform player;
    private Transform firePoint;
    [SerializeField] private float grabDistance;

    private bool boxGrabbed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null) return;

        
        firePoint = GameObject.FindGameObjectWithTag("Player FirePoint").transform;
        if (firePoint == null) return;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, player.position) < grabDistance)
        {
            boxGrabbed = !boxGrabbed;

            //if (InventoryManager.objectHeld == 0)
           // {
          //      InventoryManager.objectChange(1);
          //      Destroy(gameObject);
          //  }
        }

        if (boxGrabbed)
        {
            transform.position = firePoint.position;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
        

    }
}
