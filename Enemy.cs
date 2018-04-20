using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;
    public Text healthText;

    public GameManager theGameManager;

    public void takeDamage(int dmgToTake)
    {
        if (dmgToTake >= health)
        {
            theGameManager.GameOver(this.gameObject);
        }
        else
        {
            health = health - dmgToTake;
            healthText.text = "Enemy health:\n" + health;
        }
    }
}
