using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewTestScript
{
    private FinishLine finishScript;
    private GameObject finishTrigger;
    private GameObject player;
    private PlayerMovement playerMovement;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene("SampleScene");

        yield return new WaitForSeconds(1f);

        player = GameObject.FindGameObjectWithTag("Player");
        finishTrigger = GameObject.FindGameObjectWithTag("Finish");

        playerMovement = player.GetComponent<PlayerMovement>();

        if (finishTrigger != null)
        {
            player.GetComponent<PlayerMovement>();
            finishScript = finishTrigger.GetComponent<FinishLine>();
        }
        else
        {
            Assert.Fail("Finish GameObject with tag 'Finish' not found.");
        }
    }

/*    [UnityTest]
    public IEnumerator PlayerReachesFinishLine()
    {
        float moveDuration;
        float elapsedTime = 0f;
        bool movingLeft = true;

        yield return new WaitForSeconds(3f);

        playerMovement.gameManager.gameStarted = true;

        playerMovement.moveSpeed = 7f;

        while (!finishScript.finishedLevel)
        {
            Debug.Log("Level isn't completed yet");

            moveDuration = Random.Range(0.2f, 1f);

            if (elapsedTime >= moveDuration)
            {
                movingLeft = !movingLeft;
                elapsedTime = 0f;
            }

            if (movingLeft) playerMovement.movement.x = -1f;
            else playerMovement.movement.x = 1f;

            Vector3 newPosition = playerMovement.player.position + playerMovement.movement * playerMovement.moveSpeed * Time.fixedDeltaTime;

            playerMovement.player.position = new Vector3(newPosition.x, newPosition.y, Mathf.Clamp(newPosition.z, -7, 5));

            yield return new WaitForFixedUpdate();

            elapsedTime += Time.fixedDeltaTime;
        }

        Assert.IsTrue(finishScript.finishedLevel, "Level should be completed");

        yield return new WaitForSeconds(2f);
    }*/

    [UnityTest]
    public IEnumerator PlayerCollidesWithCarInRuntime()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject car = GameObject.FindWithTag("Car");

        Assert.IsNotNull(player, "No player");
        Assert.IsNotNull(car, "No Car");

        Collider playerCollider = player.GetComponent<Collider>();
        Collider carCollider = car.GetComponentInChildren<Collider>();

        Assert.IsNotNull(playerCollider, "No PlayerCollider");
        Assert.IsNotNull(carCollider, "No CarCollider");

        while (!playerCollider.bounds.Intersects(carCollider.bounds))
        {
            yield return null;
        }

        Assert.IsTrue(playerCollider.bounds.Intersects(carCollider.bounds), "No collision");
        Debug.Log("They collided!");
    }

    [UnityTest]
    public IEnumerator PlayerHitTruckLoseHealth()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject truck = GameObject.FindWithTag("Truck");

        Assert.IsNotNull(player, "No player");
        Assert.IsNotNull(truck, "No Truck");

        Collider playerCollider = player.GetComponentInChildren<Collider>();
        Collider carCollider = truck.GetComponentInChildren<Collider>();

        Assert.IsNotNull(playerCollider, "No PlayerCollider");
        Assert.IsNotNull(carCollider, "No TruckCollider");

        while (!playerCollider.bounds.Intersects(carCollider.bounds))
        {
            playerMovement.movement.x = 1f;

            yield return null;
        }

        Assert.IsTrue(playerCollider.bounds.Intersects(carCollider.bounds), "No collision");
        Debug.Log("They collided!");

        Assert.AreEqual(player.GetComponent<PlayerHealth>().currentHealth, 2, "Current health is not 2");
    }
}
