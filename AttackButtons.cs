using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    public Mace mace;
    public Grenade grenade;

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
    }

}
