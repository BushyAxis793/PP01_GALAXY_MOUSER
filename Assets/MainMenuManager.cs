using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelOne(int sceneIndex)
    {
        sceneIndex = 1;
        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevelThird()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevelFourth()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevelFifth()
    {
        SceneManager.LoadScene(5);
    }
    public void Options()
    {
        
    }

    public void ExitApplication()
    {
        Application.Quit();
    }


}
