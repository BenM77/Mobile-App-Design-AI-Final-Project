using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    int health;

    public Text healthText;
    public Image healthBar;

    [HideInInspector] public bool facingRight = true;

    public GameManager theGameManager;


    private void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(int dmgToTake)
    {
        if (dmgToTake >= health)
        {
            health = 0;
            healthText.text = "Enemy health:\n" + health;
            theGameManager.GameOver(this.gameObject);
        }
        else
        {
            health = health - dmgToTake;
            healthText.text = "Enemy health:\n" + health;
        }
    }

    void Update()
    {
        healthBar.fillAmount = (float)health / maxHealth;
    }
}
