using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public ScoreUI scoreUI;
    public Text scoreText;
    public Text highScoreText;

    private void Start()
    {
        scoreText.text = scoreUI.scoreText.text;

        if (scoreUI.score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", (int)scoreUI.score);
        }

        highScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
