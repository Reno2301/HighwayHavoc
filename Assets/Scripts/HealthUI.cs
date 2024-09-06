using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image[] hearts;
    public PlayerHealth playerHealth;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.maxHealth)
            {
                hearts[i].enabled = i < playerHealth.currentHealth;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
