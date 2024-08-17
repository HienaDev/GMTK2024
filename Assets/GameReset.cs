using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    private string currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(currentScene);
        }
    }
}
