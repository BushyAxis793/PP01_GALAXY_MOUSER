using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelOne(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void Options()
    {
        
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }

  

}
