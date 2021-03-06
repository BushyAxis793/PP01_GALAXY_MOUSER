﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject optionsMenu;

    private void Update()
    {
        BackToMainMenu();
    }
    public void NewGame()
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
    public void MuteMusic()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        var audioSource = musicPlayer.GetComponent<AudioSource>();

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}
