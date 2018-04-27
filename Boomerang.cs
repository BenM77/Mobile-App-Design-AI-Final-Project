using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    //Animator grenadeAnimator;
    public int boomerangDamage;
	
	public Transform target;
	public float returnSpeed;

    public void Update()
    {
		//Get user location, and apply force to move boomerang closer to the user
		float step = returnSpeed * Time.deltaTime;
		
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newHitObject = collision.gameObject;
		
        if (newHitObject.tag == "Enemy") 
		{
            newHitObject.SendMessage("takeDamage", boomerangDamage);
			
			//Set boomerangSprite to active on the player
			
			
			this.gameObject.SetActive(false);
		}
		else if(newHitObject.tag == "Player")
		{
			//Set boomerangSprite to active on the player
			
			
			this.gameObject.SetActive(false);
		}
    }

}