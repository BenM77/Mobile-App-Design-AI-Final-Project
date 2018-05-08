using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : Weapon
{
    public int punchDamage;

    bool punching;

    public Animator punchAnimator;

    void Start()
    {
        punchAnimator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(punchAnimator.GetCurrentAnimatorStateInfo(0).IsName("Throw Punch"))
            Damage(collision.gameObject, punchDamage);
    }

    public void Punch()
    {
        punchAnimator.SetTrigger("Punching");
    }

}
