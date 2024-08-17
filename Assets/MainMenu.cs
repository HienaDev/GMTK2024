using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameScene;

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
