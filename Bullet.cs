using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    public int bulletDamage;  //Should be less than arrow damage

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newHitObject = collision.gameObject;
        if (newHitObject.tag == "Player" || newHitObject.tag == "Enemy")
		{
			newHitObject.SendMessage("takeDamage", bulletDamage);
		}
		
	this.gameObject.SetActive(false);
    }

}
