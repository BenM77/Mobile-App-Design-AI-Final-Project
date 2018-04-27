using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomerangSprite : MonoBehaviour
{
    public GameObject boomerang;
    public int throwForceX, throwForceY;
    
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

    public void Throw(Player player)
    {
        //uses--;
        //grenadeCount.text = "Grenades:\n" + uses;
        int throwRight = 1;
        if (!player.facingRight)
            throwRight = -1;

        GameObject newBoomerang = Instantiate(boomerang, player.transform.position + new Vector3((float)1 * throwRight, (float).5), Quaternion.identity);
        //newGrenade.tag = "ThrownWeapon";
        //newGrenade.GetComponent<Animator>().SetTrigger("Thrown");
		
		//Disable Gravity 
		//Can we just make them, arrows and boomerang, kinematic?
		newBoomerang.GetComponent<Rigidbody2D>.gravityScale = 0f;
		
        newBoomerang.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * throwRight, 0));
        newBoomerang.GetComponent<Rigidbody2D>().AddTorque(360, ForceMode2D.Impulse);

		this.gameObject.SetActive(false);
        //grenadeCount.text = "";


    }
}