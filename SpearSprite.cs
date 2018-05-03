using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSprite : MonoBehaviour
{
    public GameObject spear;
    public int throwForceX;

    public void Throw(Character thrower)
    {

        int throwRight = 1;
        if (!thrower.facingRight)
            throwRight = -1;

        GameObject newSpear = Instantiate(spear, thrower.transform.position + new Vector3((float)1 * throwRight, (float)1), Quaternion.identity);
        newSpear.tag = "ThrownWeapon";
        //newSpear.GetComponent<Animator>().SetTrigger("Thrown");
        newSpear.GetComponent<Rigidbody2D>.gravityScale = 0f;
        newSpear.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForceX * throwRight, 0));
    }
}
