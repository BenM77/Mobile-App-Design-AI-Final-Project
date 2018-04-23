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
        if(swinging)
            Damage(collision.gameObject, maceDamage);
    }

    public void Swing() //also plays the animation
    {
        swinging = true;
        maceAnimator.SetTrigger("Swinging");
    }

    private void Update()
    {
        //swinging = false;
    }

}
