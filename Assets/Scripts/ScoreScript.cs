using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }

    public void ScoreCount(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }

}
