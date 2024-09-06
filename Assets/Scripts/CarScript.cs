using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    GameManager gameManager;

    public GameObject player;
    public GameObject explosionPrefab;
    public HighwayMovement highwayScript;

    BonusText bonusTextScript;
    ScoreUI score;

    public float carSpeed;
    public float speedDifference = 0.2f;
    public float highwayToCarSpeed = 33;

    private float startFlyFactor = 0;
    public float flyFactor = 0.04f;

    private bool hit;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject scoreUI = GameObject.Find("ScoreUI");
        score = scoreUI.GetComponent<ScoreUI>();
        bonusTextScript = scoreUI.GetComponent<BonusText>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hit = false;

        float randomFloat = Random.Range(1 - speedDifference, 1 + speedDifference);

        carSpeed = highwayScript.highwaySpeed / highwayToCarSpeed;

        carSpeed *= randomFloat;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStarted)
        {
            gameObject.transform.position += new Vector3(0, 0, -carSpeed) * Time.deltaTime;

            transform.position += new Vector3(0, startFlyFactor * 2, startFlyFactor);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hit)
        {
            hit = true;
            startFlyFactor = flyFactor;

            bonusTextScript.ShowBonusText();

            score.scoreFactor += 1;

            score.score += 200;

            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject, 0.2f);
    }
}
