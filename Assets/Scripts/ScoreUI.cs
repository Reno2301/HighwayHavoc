using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Text scoreText;

    public float score = 0f;
    public float scoreFactor = 1f;
    public float randomExtraFactor = 7f;

    // Update is called once per frame
    void Update()
    {
        if (!playerHealth.IsDead())
        {
            score += Time.deltaTime * scoreFactor * randomExtraFactor;
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }
}
