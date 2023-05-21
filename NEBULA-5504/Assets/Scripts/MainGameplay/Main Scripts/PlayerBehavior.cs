using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private GameObject boxPrefab;

    TestSceneManager sceneManager;

    private void Awake()
    {
        boxPrefab = Resources.Load<GameObject>("Prefabs/BoxParent");
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TestSceneManager>();
    }

    private void Update()
    {
        if (InventoryManager.objectHeld == 1 && Input.GetKeyDown(KeyCode.E))
        {
            GameObject box = Instantiate(boxPrefab, firePoint.position, Quaternion.identity);

            if (sceneManager.dimension == 1)
            {
                Debug.Log("shuigsaiuga");
                box.tag = "ObjLv1";
                sceneManager.ObjectAdded(1);
            }
            if (sceneManager.dimension == 2)
            {
                Debug.Log("shuigsaiuga");
                box.tag = "ObjLv2";
                sceneManager.ObjectAdded(2);
            }


            InventoryManager.objectChange(0);
        }
    }
}
