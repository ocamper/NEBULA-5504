using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneManager : MonoBehaviour
{
    GameObject[] objLv1;
    GameObject[] objLv2;

    public int dimension = 1;

    [SerializeField] private GameObject fxTrans;

    private void Awake()
    {
        objLv1 = GameObject.FindGameObjectsWithTag("ObjLv1");
        objLv2 = GameObject.FindGameObjectsWithTag("ObjLv2");

        foreach (GameObject gameObject in objLv1)
        {
            if (gameObject != null)
                gameObject.SetActive(true);
        }
        foreach (GameObject gameObject in objLv2)
        {
            if (gameObject != null)
                gameObject.SetActive(false);
        }
    }

    public void ObjectAdded(int objType)
    {
        if (objType == 1)
            objLv1 = GameObject.FindGameObjectsWithTag("ObjLv1");

        if (objType == 2)
            objLv2 = GameObject.FindGameObjectsWithTag("ObjLv2");
    }

    private void Update()
    {

        if (dimension == 1)
        {
            foreach (GameObject gameObject in objLv1)
            {
                if (gameObject != null)
                    gameObject.SetActive(true);
            }
            foreach (GameObject gameObject in objLv2)
            {
                if (gameObject != null)
                    gameObject.SetActive(false);
            }
        }
        else 
        {
            foreach (GameObject gameObject in objLv1)
            {
                if (gameObject != null)
                    gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in objLv2)
            {
                if (gameObject != null)
                    gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (PlayerMovement.teleportAvailable)
            {
                if (dimension == 1)
                    StartCoroutine(TeleportSequence(2));
                else
                    StartCoroutine(TeleportSequence(1));
            }
            else
            {
                Debug.Log("ERROR: COULD NOT TELEPORT - WALL BLOCKING THE OTHER SIDE");
            }
        }
            
    }

    IEnumerator TeleportSequence(int switchDimension)
    {
        Time.timeScale = 0;
        fxTrans.SetActive(true);
        yield return new WaitForSecondsRealtime(0.33f);
        dimension = switchDimension;
        yield return new WaitForSecondsRealtime(0.9f);
        fxTrans.SetActive(false);
        Time.timeScale = 1;
    }
}
