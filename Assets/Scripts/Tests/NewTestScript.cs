using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class NewTestScript
{
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene("SampleScene");

        yield return null;
    }

    /*    [UnityTest]
        public IEnumerator PlayerCollidesWithCarInRuntime()
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject car = GameObject.FindWithTag("Car");

            Assert.IsNotNull(player, "No player");
            Assert.IsNotNull(car, "No Car");

            Collider playerCollider = player.GetComponentInChildren<Collider>();
            Collider carCollider = car.GetComponentInChildren<Collider>();

            Assert.IsNotNull(playerCollider, "No PlayerCollider");
            Assert.IsNotNull(carCollider, "No CarCollider");

            while (!playerCollider.bounds.Intersects(carCollider.bounds))
            {
                yield return null;
            }

            Assert.IsTrue(playerCollider.bounds.Intersects(carCollider.bounds), "No collision");
            Debug.Log("They collided!");
        }*/

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
            yield return null;
        }

        Assert.IsTrue(playerCollider.bounds.Intersects(carCollider.bounds), "No collision");
        Debug.Log("They collided!");

        Assert.AreEqual(player.GetComponent<PlayerHealth>().currentHealth, 2, "Current health is not 2");
    }
}
