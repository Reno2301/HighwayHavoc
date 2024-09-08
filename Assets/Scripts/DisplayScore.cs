using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public ScoreUI scoreUI;
    public Text text;

    private void Start()
    {
        text.text = "SCORE: " + scoreUI.scoreText.text;
    }
}
