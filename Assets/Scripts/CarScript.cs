using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    public GameObject player;

    public GameObject explosionPrefab;

    public HighwayMovement highwayScript;

    public Text bonusText;

    ScoreUI score;

    public float carSpeed;
    public float speedDifference = 0.2f;
    public float highwayToCarSpeed = 33;

    private float startFlyFactor = 0;
    public float flyFactor = 0.04f;

    private bool hit;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;

        score = GameObject.Find("ScoreUI").GetComponent<ScoreUI>();
        bonusText = GameObject.Find("BonusScore").GetComponent<Text>();

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
        if (collision.gameObject.CompareTag("Player") && !hit)
        {
            startFlyFactor = flyFactor;

            score.scoreFactor += 1;

            bonusText.text = "+200";

            score.score += 200;

            StartCoroutine(Explode());
            hit = true;
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.6f);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.2f);
        bonusText.text = "";
        Destroy(gameObject);
    }
}
