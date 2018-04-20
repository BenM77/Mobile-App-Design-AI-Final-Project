using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : Weapon
{
    public int maceDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision.gameObject, maceDamage);
    }

}
