using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    public Mace mace;
    public GrenadeSprite grenade;
    //public BowSprite bow;
    public BoomerangSprite boomerang;
    
    //public Character thrower;

    public void AttackOne()
    {
        //default attack
    }

    public void AttackTwo(Character thrower)
    {
        if (mace.gameObject.activeInHierarchy)
        {
            mace.Swing();
        }
        else if (grenade.gameObject.activeInHierarchy)
        {
            grenade.Throw(thrower);
        }
        //else if (bow.gameObject.activeInHierarchy)
        //{
        //    bow.Shoot(player);
        //}
        else if (boomerang.gameObject.activeInHierarchy)
        {
            boomerang.Throw(thrower);
        }
    }

}
