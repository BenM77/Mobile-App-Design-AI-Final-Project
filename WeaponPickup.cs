using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject maceSprite;
    public GameObject grenadeSprite;
    public GameObject boomerangSprite;
    public GameObject bowSprite;

    [HideInInspector] public GameObject activeSprite;

    private void Start()
    {
        activeSprite = maceSprite;
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
        else if(collision.gameObject.tag == "Boomerang")
        {
            activeSprite.SetActive(false);
            activeSprite = boomerangSprite;
            SwitchWeapons(collision.gameObject);

        }
        else if (collision.gameObject.tag == "Bow")
        {
            activeSprite.SetActive(false);
            activeSprite = bowSprite;
            SwitchWeapons(collision.gameObject);
        }
    }

    void SwitchWeapons(GameObject toDestroy)
    {
        activeSprite.SetActive(true);
        Destroy(toDestroy);
    }
}
