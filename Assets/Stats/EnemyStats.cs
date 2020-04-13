using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected override void Die()
    {
        animator.SetInteger("animation", 4);
        isDeath = true;
    }
}
