using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    public int arrowDamage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newHitObject = collision.gameObject;
        if (newHitObject.tag == "Player" || newHitObject.tag == "Enemy")
		{
			newHitObject.SendMessage("takeDamage", arrowDamage);
		}
		
	this.gameObject.SetActive(false);
    }

}
