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

    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        carsSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (gameManager.isPlaying)
        {
            if (!carsSpawned)
            {
                GameObject firstCar = carPrefabs[Random.Range(0, carPrefabs.Length)];
                GameObject secondCar = carPrefabs[Random.Range(0, carPrefabs.Length)];

                Vector3 firstPos = spawnPositions[Random.Range(0, spawnPositions.Length / 2)].transform.position;
                Vector3 secondPos = spawnPositions[Random.Range(spawnPositions.Length - spawnPositions.Length / 2, spawnPositions.Length)].transform.position;

                if (firstCar.CompareTag("Truck")) firstPos.y = 0f;
                else if (firstCar.CompareTag("Car")) firstPos.y = 0.5f;

                if (secondCar.CompareTag("Truck")) secondPos.y = 0f;
                else if (secondCar.CompareTag("Car")) secondPos.y = 0.5f;

                StartCoroutine(Spawn(firstCar, secondCar, firstPos, secondPos));
            }

            if (elapsedTime >= 20)
            {
                NextLevel();

                elapsedTime = 0;
            }
        }
    }

    private IEnumerator Spawn(GameObject gameObject1, GameObject gameObject2, Vector3 spawnPos1, Vector3 spawnPos2)
    {
        carsSpawned = true;

        Instantiate(gameObject1, spawnPos1, Quaternion.identity);
        Instantiate(gameObject2, spawnPos2, Quaternion.identity);

        yield return new WaitForSeconds(spawnDelay);

        carsSpawned = false;
    }

    private void NextLevel()
    {
        if (spawnDelay >= 1.8)
        {
            spawnDelay -= 0.2f;
        }
        else
        {
            spawnDelay = 1.8f;
        }
    }
}
