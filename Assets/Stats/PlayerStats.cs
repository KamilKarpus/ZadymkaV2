using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();  
    }
    protected override void Die()
    {
        base.Die();
        animator.SetInteger("condition", 10);
        isDeath = true;
    }
}
