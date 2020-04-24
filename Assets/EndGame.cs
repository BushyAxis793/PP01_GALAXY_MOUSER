using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject endgameImage;
    [SerializeField] GameObject finalBoss;

    BossScript bossScript;

    private void Start()
    {
        bossScript = FindObjectOfType<BossScript>();
    }
    private void Update()
    {


        if (!finalBoss.activeInHierarchy)
        {
            endgameImage.SetActive(true);
            Cursor.visible = true;
        }

       
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
