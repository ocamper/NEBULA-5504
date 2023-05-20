using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class positionHandler : MonoBehaviour
{
    public static Vector2 preTpPosition;
    public static int currentScene;

    private void Start()
    {
        preTpPosition = new Vector2(-7.15f, 0);
    }

    public static void SceneChange(Transform transform)
    {
        preTpPosition = transform.position;
        Debug.Log(preTpPosition);

        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0)
            SceneManager.LoadScene(currentScene + 1);

        if (currentScene == 1)
            SceneManager.LoadScene(currentScene - 1);

    }
}
