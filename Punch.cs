using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : Weapon
{
    public int punchDamage;

    bool punching;
    
    public Character target;

    public Animator punchAnimator;

    void Start()
    {
        punchAnimator = GetComponent<Animator>();
    }
    
    void OnEnable() 
    {
    //target.weapon.SetActive(false);
    }
    
    void OnDisable()
    {
    //target.weapon.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(punchAnimator.GetCurrentAnimatorStateInfo(0).IsName("Throw Punch"))
            Damage(collision.gameObject, punchDamage);
            
        this.gameObject.SetActive(false);    
    }

    public void Punch()
    {
        punchAnimator.SetTrigger("Punching");
    }

}
