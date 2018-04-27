using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    public int spearDamage;

    bool attacking;

    public Animator spearAnimator;

    void Start()
    {
        spearAnimator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(spearAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spear Attack"))
            Damage(collision.gameObject, spearDamage);
    }

    public void Attack()
    {
        spearAnimator.SetTrigger("Attacking");
    }

}