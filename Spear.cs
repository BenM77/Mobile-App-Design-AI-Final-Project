using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    public int spearDamage;

    private void OnCollisionEnter2D(Collider2D collision)
    {
        GameObject newHitObject = collision.gameObject;
        if (newHitObject.tag == "Player" || newHitObject.tag == "Enemy")
		    {
			    newHitObject.SendMessage("takeDamage", spearDamage);
		    }
		
	      this.gameObject.SetActive(false);
    }

}
