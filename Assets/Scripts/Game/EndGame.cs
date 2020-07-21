using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject endGameUI;

    BossScript bossScript;

    private void Start()
    {
        bossScript = FindObjectOfType<BossScript>();
    }
    private void Update()
    {
        LoadLastCanvas();
    }
    private void LoadLastCanvas()
    {
        if (bossScript != null) return;

        if (endGameUI == null) return;

        endGameUI.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
