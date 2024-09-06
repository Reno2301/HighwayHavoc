using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;

    Rigidbody player;

    public float moveSpeed = 5f;

    Vector3 movement;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameManager.gameStarted)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");

            player.position = new Vector3(player.position.x, player.position.y, Mathf.Clamp(player.position.z, -7, 5));
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.gameStarted)
        {
            player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
