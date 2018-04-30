using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowSprite : MonoBehaviour
{
    public GameObject upArrow;
	public GameObject straightArrow;
	public GameObject downArrow;
    public int throwForceX;
   
    public int maxUses;
    int uses;
    public Text arrowCount;

    public void OnEnable() //called whenever the script is enabled or reenabled
    {
        uses = maxUses;
        arrowCount.text = "Arrows:\n" + uses;
    }
    
    public void OnDisable()
    {
    	arrowCount.text = "";
    }
    
    public void Shoot(Player player)
    {
        uses--;
        arrowCount.text = "Arrows:\n" + uses;
        int throwRight = 1;
        if (!player.facingRight)
            throwRight = -1;
			
		//This shoots 3 arrows with the same horizontal speed and different vertical speeds
        GameObject newArrow1 = Instantiate(upArrow, player.transform.position + new Vector3((float)1 * throwRight, (float).5), Quaternion.identity);
	GameObject newArrow2 = Instantiate(straightArrow, player.transform.position + new Vector3((float)1 * throwRight, (float).5), Quaternion.identity);
        GameObject newArrow3 = Instantiate(downArrow, player.transform.position + new Vector3((float)1 * throwRight, (float).5), Quaternion.identity);

        //newArrow1.tag = "ThrownWeapon";        
        //newArrow1.GetComponent<Animator>().SetTrigger("Thrown");
        
		//Disable gravity for all arrows
		//newArrow1.GetComponent<Rigidbody2D>.gravityScale = 0f;
		//newArrow2.GetComponent<Rigidbody2D>.gravityScale = 0f;
		//newArrow3.GetComponent<Rigidbody2D>.gravityScale = 0f;

		//To shoot arrows at a 45 degree angle, y force must be the same as x force
		newArrow1.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * throwRight, throwForceX));
		newArrow2.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * sqrt(2) * throwRight, 0));
		//To make same velocity vectors, multiply newArrow2 by sqrt(2) 
		newArrow3.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * throwRight, -throwForceX));

        
	if (uses == 0)
        {
            this.gameObject.SetActive(false);
            //arrowCount.text = "";
        }
    }
}
