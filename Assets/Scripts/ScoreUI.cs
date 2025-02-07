using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    GameManager gameManager;

    public PlayerHealth playerHealth;

    public float highScore;
    public Text scoreText;
    public Text highScoreText;

    public float score = 0f;
    public float scoreFactor = 1f;
    public float randomExtraFactor = 7f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPlaying)
        {
            if (!playerHealth.IsDead())
            {
                score += Time.deltaTime * scoreFactor * randomExtraFactor;
                scoreText.text = Mathf.FloorToInt(score).ToString();
            }
        }
    }
}
