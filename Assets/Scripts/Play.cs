using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] bool isActive;

    void Awake()
    {
        isActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            mainMenu.SetActive(false);
            Debug.Log("Закрыл");
            isActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isActive)
        {
            mainMenu.SetActive(true);
            Debug.Log("Открыл");
            isActive = true;
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        } 
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
