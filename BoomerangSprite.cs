using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomerangSprite : MonoBehaviour
{
    public GameObject boomerang;
    public int throwForceX;
    
	/*bool throwable;

	//public int maxUses;
    //int uses;
    //public Text grenadeCount;

    public void OnEnable() //called whenever the script is enabled or reenabled
    {
        //uses = maxUses;
        //grenadeCount.text = "Grenades:\n" + uses;
		
		bool throwable = true;
    }
	*/

    public void Throw(Character thrower)
    {
        int throwRight = 1;
        if (!thrower.facingRight)
            throwRight = -1;

        GameObject newBoomerang = Instantiate(boomerang, thrower.transform.position + new Vector3((float)1 * throwRight, (float).5), Quaternion.identity);
        newBoomerang.GetComponent<Rigidbody2D>().gravityScale = 0;
        newBoomerang.SendMessage("setTarget", thrower);
        if(throwRight == -1)
        {
            Vector3 theScale = newBoomerang.transform.localScale;
            theScale.x *= -1;
            newBoomerang.transform.localScale = theScale;
        }
        //newGrenade.GetComponent<Animator>().SetTrigger("Thrown");
		
        newBoomerang.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * throwRight, 0));
        //newBoomerang.GetComponent<Rigidbody2D>().AddTorque(360, ForceMode2D.Impulse); //makes the boomerang freak out

		this.gameObject.SetActive(false);
    }
}