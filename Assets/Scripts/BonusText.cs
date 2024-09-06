using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusText : MonoBehaviour
{
    public GameObject bonusText;
    public float bonusDuration;

    private void Start()
    {
        bonusText.SetActive(false);
    }
    public void ShowBonusText()
    {
        bonusText.SetActive(true);
        StartCoroutine(HideBonusText());
    }

    public IEnumerator HideBonusText()
    {
        yield return new WaitForSeconds(bonusDuration);

        bonusText.gameObject.SetActive(false);
    }
}
