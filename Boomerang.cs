using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    //Animator grenadeAnimator;
    public int boomerangDamage;
    public GameObject boomerangSprite;

    public Character target;
    //public float returnSpeed;
    public float returnForce;

    Rigidbody2D boomerangRB2D;

    public void Start()
    {
        boomerangRB2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //Get user location, and apply force to move boomerang closer to the user
        //float step = returnSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        boomerangRB2D.AddForce((target.transform.position - transform.position).normalized * returnForce);//add a force in the direction of the thrower
        
        //Vector3 theScale = transform.localScale;
        //if ((boomerangRB2D.velocity.x < 0 && theScale.x > 0) || (boomerangRB2D.velocity.x > 0 && theScale.x < 0)) //correct the sprites orientation
        //{
        //    theScale.x *= -1;
        //    transform.localScale = theScale;
        //}
    }

    public void setTarget(Character newTarget)
    {
        target = newTarget;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newHitObject = collision.gameObject;
		
        if (newHitObject.tag == "Enemy" || newHitObject.tag == "Player") 
		{
            if (newHitObject == target)
            {
                //boomerangSprite.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                newHitObject.SendMessage("takeDamage", boomerangDamage);
            }
		}
    }
}