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

    private BonusText bonusTextScript;
    private ScoreUI score;

    public AudioSource explosionSfx;
    public AudioSource[] hitSfxs;

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
        if (gameManager.isPlaying)
        {
            gameObject.transform.position += new Vector3(0, 0, -carSpeed) * Time.deltaTime;

            transform.position += new Vector3(0, startFlyFactor * 2, startFlyFactor);

            if (Vector3.Distance(transform.position, player.transform.position) > 100)
            {
                DeleteCar();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hit)
        {
            hitSfxs[Random.Range(0, 2)].Play();

            hit = true;

            startFlyFactor = flyFactor;

            bonusTextScript.ShowBonusText();

            score.scoreFactor += 1;

            score.score += 200;

            StartCoroutine(Explode());
        }
    }

    void DeleteCar()
    {
        Destroy(gameObject);
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        explosionSfx.Play();

        MeshRenderer[] meshes = gameObject.GetComponentsInChildren<MeshRenderer>();

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = false;
        }

        Destroy(gameObject, 2f);
    }
}
