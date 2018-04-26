using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : Weapon
{
    public int maceDamage;

    bool swinging;

    public Animator maceAnimator;

    void Start()
    {
        maceAnimator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(maceAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mace Swing"))
            Damage(collision.gameObject, maceDamage);
    }

    public void Swing()
    {
        maceAnimator.SetTrigger("Swinging");
    }

}
