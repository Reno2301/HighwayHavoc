using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody player;

    public float moveSpeed = 5f;

    Vector3 movement;

    private void Start()
    {
        player = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        player.position = new Vector3(player.position.x, player.position.y, Mathf.Clamp(player.position.z, -7, 5));
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
