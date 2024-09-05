using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject highwayPrefab;
    public GameObject loadNextHighway;
    public GameObject deleteHighway;

    public float highwaySpeed = 1f;
    private bool hasSpawned;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        highwayPrefab = gameObject;
        hasSpawned = false;
        highwayPrefab.name = "Highway";
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(0, 0, -highwaySpeed * 0.1f) * Time.deltaTime;

        SpawnHighway();
        DeleteHighway();
    }

    void SpawnHighway()
    {
        if (Vector3.Distance(loadNextHighway.transform.position, player.transform.position) < 50 && !hasSpawned)
        {
            Instantiate(highwayPrefab, loadNextHighway.transform.position, Quaternion.identity);
            hasSpawned = true;
        }
    }

    void DeleteHighway()
    {
        if (Vector3.Distance(deleteHighway.transform.position, player.transform.position) > 150)
        {
            Destroy(gameObject);
        }
    }
}
