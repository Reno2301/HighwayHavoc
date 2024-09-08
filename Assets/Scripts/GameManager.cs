using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int secondsBeforeStartingGame;
    public bool isPlaying;

    public Text startingGameText;
    public float startingFloat;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
        startingFloat = 4f;
        StartCoroutine(StartingGame());
    }

    IEnumerator StartingGame()
    {
        yield return new WaitForSeconds(secondsBeforeStartingGame);
        isPlaying = true;
    }

    private void Update()
    {
        startingFloat -= Time.deltaTime;

        if (startingFloat > 1)
        {
            startingGameText.text = Mathf.FloorToInt(startingFloat).ToString();
        }

        if (startingFloat <= 1)
        {
            startingGameText.text = "GO!";
        }

        if (startingFloat <= -0.5f)
        {
            Destroy(startingGameText);
        }
    }
}
