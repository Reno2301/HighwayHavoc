using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;

    Rigidbody player;

    public float moveSpeed = 5f;

    public Vector3 movement;

    private float brakeSpeed;

    public float brakeSpeedExtra = 1.5f;
    private float brakeSpeedNormal = 1f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameManager.isPlaying)
        {
            GetInput();
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.isPlaying)
        {
            MovePosition();
        }
    }

    public void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if(movement.z < 0)
        {
            brakeSpeed = 1.5f;
        }
        else
        {
            brakeSpeed = brakeSpeedNormal;
        }
    }

    public void MovePosition()
    {
        player.position = new Vector3(Mathf.Clamp(player.position.x, -5, 5), player.position.y, Mathf.Clamp(player.position.z, -8, 7));

        player.MovePosition(player.position + movement * moveSpeed * brakeSpeed * Time.fixedDeltaTime);
    }
}
