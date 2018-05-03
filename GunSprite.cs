using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSprite : MonoBehaviour
{
    public GameObject bullet;
    public int throwForceX; //For balancing, recommend faster than bow with less damage and similar number of uses
   
    public int maxUses;
    int uses;
    public Text bulletCount;

    public void OnEnable() //called whenever the script is enabled or reenabled
    {
        uses = maxUses;
        bulletCount.text = "Bullets:\n" + uses;
    }
    
    public void OnDisable()
    {
    	bulletCount.text = "";
    }
    
    public void Shoot(Player player)
    {
        uses--;
        bulletCount.text = "Arrows:\n" + uses;
        int throwRight = 1;
        if (!player.facingRight)
            throwRight = -1;
			
		//This shoots 3 arrows with the same horizontal speed and different vertical speeds
        GameObject newBullet = Instantiate(bullet, player.transform.position + new Vector3((float)1 * throwRight, (float).5), Quaternion.identity);
	
    newBullet.tag = "ThrownWeapon";        
    //newBullet.GetComponent<Animator>().SetTrigger("Thrown");
        
		//Disable gravity for all arrows
		newBullet.GetComponent<Rigidbody2D>.gravityScale = 0f;
		
		//To shoot arrows at a 45 degree angle, y force must be the same as x force
		newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * throwRight, 0));
		        
	  if (uses == 0)
        {
            this.gameObject.SetActive(false);
            bulletCount.text = "";
        }
    }
}
