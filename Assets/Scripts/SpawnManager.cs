using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    GameManager gameManager;

    public GameObject[] spawnPositions;
    public GameObject[] carPrefabs;

    public float spawnDelay = 1f;

    private bool carsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        carsSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPlaying)
        {
            if (!carsSpawned)
            {
                StartCoroutine(Spawn(carPrefabs[Random.Range(0, carPrefabs.Length)], carPrefabs[Random.Range(0, carPrefabs.Length)], 
                    spawnPositions[Random.Range(0, spawnPositions.Length / 2)].transform.position,
                    spawnPositions[Random.Range(spawnPositions.Length - spawnPositions.Length / 2, spawnPositions.Length)].transform.position));
            }
        }
    }

    IEnumerator Spawn(GameObject gameObject1, GameObject gameObject2, Vector3 spawnPos1, Vector3 spawnPos2)
    {
        carsSpawned = true;

        Instantiate(gameObject1, spawnPos1, Quaternion.identity);
        Instantiate(gameObject2, spawnPos2, Quaternion.identity);

        yield return new WaitForSeconds(spawnDelay);

        carsSpawned = false;
    }
}
