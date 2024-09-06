using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    public HighwayMovement highwayScript;

    public float truckSpeed;
    public float speedDifference = 0.1f;
    public float highwayToTruckSpeed = 33;

    void Start()
    {
        float randomFloat = Random.Range(1 - speedDifference, 1 + speedDifference);

        truckSpeed = highwayScript.highwaySpeed / highwayToTruckSpeed;

        truckSpeed *= randomFloat;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, 0, -truckSpeed) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
