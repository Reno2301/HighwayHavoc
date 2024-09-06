using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public GameObject player;

    public GameObject explosionPrefab;

    public HighwayMovement highwayScript;

    ScoreUI score;

    public float carSpeed;
    public float speedDifference = 0.2f;
    public float highwayToCarSpeed = 33;

    private float startFlyFactor = 0;
    public float flyFactor = 0.04f;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("ScoreUI").GetComponent<ScoreUI>();

        float randomFloat = Random.Range(1 - speedDifference, 1 + speedDifference);

        carSpeed = highwayScript.highwaySpeed / highwayToCarSpeed;

        carSpeed *= randomFloat;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, 0, -carSpeed) * Time.deltaTime;

        transform.position += new Vector3(0, startFlyFactor, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startFlyFactor = flyFactor;

            score.scoreFactor += 1;

            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.6f);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
