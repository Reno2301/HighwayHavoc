using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private float flyFactor = 4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    private void Update()
    {
        transform.position += new Vector3(0, flyFactor * 2, flyFactor) * Time.deltaTime;
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
