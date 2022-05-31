using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;

    public GameObject deathEffect;
    public UIManager uiManager;
    public GameplayManager gameManager;

    private void Start()
    {
        health = maxHealth;
        uiManager.SetMaxHealth(maxHealth);
        uiManager.SetTextHealthBar(maxHealth, health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        uiManager.SetHeatlh(health);
        uiManager.SetTextHealthBar(maxHealth, health);

        if (health <= 0)
            Die();
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, effect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        GetComponent<PlayerMovement>().enabled = false;

        Destroy(GameObject.Find("Enemy(Clone)"));
        Destroy(GameObject.Find("Spawner"));

        gameManager.SetPanelGameOver();
    }
}
