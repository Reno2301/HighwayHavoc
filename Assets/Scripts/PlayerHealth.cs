using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameManager gameManager;

    public int maxHealth = 3;
    public int currentHealth;

    public float invincibleDuration = 3f;

    public bool isInvincible = false;

    public GameObject gameOverPanel;
    public GameObject scoreUI;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("Player Health: " + currentHealth);
            StartCoroutine(InvincibilityCooldown());
        }
    }

    private void Die()
    {
        gameManager.isPlaying = false;

        gameOverPanel.SetActive(true);

        scoreUI.SetActive(false);

        Debug.Log("Player has died!");
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
    private IEnumerator InvincibilityCooldown()
    {
        isInvincible = true;
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        for (float i = 0; i < invincibleDuration; i += 0.2f)
        {
            for (int j = 0; j < renderers.Length; j++)
            {
                renderers[j].enabled = !renderers[j].enabled;
            }
            yield return new WaitForSeconds(0.2f);
        }

        for (int i = 0; i < renderers.Length; i++)
        {
        renderers[i].enabled = true;
        }
        isInvincible = false;
    }
}