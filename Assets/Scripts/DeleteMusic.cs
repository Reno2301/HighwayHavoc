using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMusic : MonoBehaviour
{
    public PlayerHealth player;
    AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsDead())
        {
            backgroundMusic.Pause();
        }
    }
}
