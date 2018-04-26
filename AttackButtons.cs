using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    public Mace mace;
    public GrenadeSprite grenade;
    public Player player;

    public void AttackOne()
    {
        //default attack
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
    }

}
