using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;

    public void OnClick()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);

    }
}
