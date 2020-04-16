using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    private Animator animator;
    public Text nameText;
    public Text lvlText;


    private void Start()
    {
        animator = GetComponent<Animator>();
        level = 99;
        name = "Pszemek";
    }
    protected override void Die()
    {
        base.Die();
        animator.SetInteger("condition", 10);
        isDeath = true;
    }

    public void Update()
    {
        lvlText.text = "Lvl: " + level.ToString();
        nameText.text = name;
    }
}
