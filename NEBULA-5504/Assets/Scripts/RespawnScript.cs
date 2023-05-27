using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadSceneAsync(DeathManager.lastScene);
        //reloadtest
    }
}
