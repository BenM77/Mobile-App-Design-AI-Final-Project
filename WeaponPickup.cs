using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject maceSprite;
    public GameObject grenadeSprite;
    GameObject activeSprite;

    private void Start()
    {
        activeSprite = maceSprite;
        activeSprite.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mace")
        {
            activeSprite.SetActive(false);
            activeSprite = maceSprite;
            SwitchWeapons(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Grenade")
        {
            activeSprite.SetActive(false);
            activeSprite = grenadeSprite;
            SwitchWeapons(collision.gameObject);
        }


    }

    void SwitchWeapons(GameObject toDestroy)
    {
        activeSprite.SetActive(true);
        Destroy(toDestroy);
    }
}
