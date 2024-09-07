using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public bool finishedLevel;
    public GameObject finishedText;

    private void Update()
    {
        gameObject.transform.position += new Vector3(0, 0, -30) * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finishedLevel = true;
            finishedText.SetActive(true);
            Debug.Log("Finished the level");
        }
    }
}
