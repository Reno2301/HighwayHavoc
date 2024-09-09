using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    GameManager gameManager;

    public GameObject player;
    public HighwayMovement highwayScript;

    ScoreUI score;

    public float truckSpeed;
    public float speedDifference = 0.1f;
    public float highwayToTruckSpeed = 28;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        score = GameObject.Find("ScoreUI").GetComponent<ScoreUI>();

        float randomFloat = Random.Range(1 - speedDifference, 1 + speedDifference);

        truckSpeed = highwayScript.highwaySpeed / highwayToTruckSpeed;

        truckSpeed *= randomFloat;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPlaying)
        {
            gameObject.transform.position += new Vector3(0, 0, -truckSpeed) * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.transform.position) > 100)
            {
                DeleteTruck();
            }
        }
    }

    void DeleteTruck()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (!playerHealth.isInvincible)
            {
                GetComponent<AudioSource>().Play();
            }

            playerHealth.TakeDamage(1);

            score.scoreFactor = 1;
        }
    }
}
