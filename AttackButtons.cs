using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    public Spear spear;
    public Mace mace;
    public GrenadeSprite grenade;
    public BowSprite bow;
    public BoomerangSprite boomerang;
    
    public Player player;

    public void AttackOne()
    {
        spear.Attack();
    }

    public void AttackTwo()
    {
        if (mace.gameObject.activeInHierarchy)
        {
            mace.Swing();
        }
        else if (grenade.gameObject.activeInHierarchy)
        {
            grenade.Throw(player);
        }
        else if (bow.gameObject.activeInHierarchy)
        {
            bow.Shoot(player);
        }
        else if (boomerang.gameObject.activeInHierarchy)
        {
            boomerang.Throw(player);
        }
    }

}
