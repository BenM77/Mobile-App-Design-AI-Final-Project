using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeSprite : MonoBehaviour
{
    public GameObject grenade;
    public int throwForceX, throwForceY;
    public int maxUses;
    int uses;
    public Text grenadeCount;

    public void OnEnable() //called whenever the script is enabled or reenabled
    {
        uses = maxUses;
        grenadeCount.text = "Grenades:\n" + uses;
    }

    public void OnDisable()
    {
        grenadeCount.text = "";
    }

    public void Throw(Character thrower)
    {
        uses--;
        grenadeCount.text = "Grenades:\n" + uses;
        int throwRight = 1;
        if (!thrower.facingRight)
            throwRight = -1;

        GameObject newGrenade = Instantiate(grenade, thrower.transform.position + new Vector3((float)1 * throwRight, (float).5), Quaternion.identity);
        newGrenade.tag = "ThrownWeapon";
        newGrenade.GetComponent<Animator>().SetTrigger("Thrown");
        newGrenade.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * throwRight, throwForceY));
        if (uses == 0)
        {
            this.gameObject.SetActive(false);
            grenadeCount.text = "";
        }
    }
}
