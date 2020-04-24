using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] AudioClip backgroundMusic;
    AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        BackToMainMenu();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevelFour()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevelFive()
    {
        SceneManager.LoadScene(5);
    }
    public void Options()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(false);
            levelMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }



}
