using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    BossScript bossScript;


    private void Start()
    {
        bossScript = FindObjectOfType<BossScript>();

    }
    private void Update()
    {
       
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
