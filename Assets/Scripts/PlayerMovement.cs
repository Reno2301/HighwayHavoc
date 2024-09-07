using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;

    public Rigidbody player;

    public float moveSpeed = 5f;

    public Vector3 movement;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameManager.gameStarted)
        {
            GetInput();
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.gameStarted)
        {
            MovePosition();
        }
    }

    public void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    public void MovePosition()
    {
        player.position = new Vector3(Mathf.Clamp(player.position.x, -5, 5), player.position.y, Mathf.Clamp(player.position.z, -7, 5));

        player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
