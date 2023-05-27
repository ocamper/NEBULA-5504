using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private int currentScene;

    public static int lastScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void playedDied()
    {
        lastScene = currentScene;
        SceneManager.LoadScene(6);
    }
}
