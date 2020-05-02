using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public float expMultiplayer = 1.2f;
    private Animator animator;
    public Text nameText;
    public Text lvlText;
    public int strength;
    public int availablePoints;

    public float currentExp = 0;
    public float neededExp;

    public void CalculateLevel()
    {
        if(currentExp >= neededExp)
        {
            currentExp -= neededExp;
            level++;
            availablePoints++;
            neededExp*=expMultiplayer;
        }
    }
    public bool AddStrength()
    {
        if(availablePoints > 0)
        {
            strength += 10;
            availablePoints--;
            return true;
        }
        return false;
    }

    public bool AddHealth()
    {
        if (availablePoints > 0)
        {
            maxHealth += 10;
            availablePoints--;
            return true;
        }
        return false;
    }

    private void Start()
    {
        neededExp = 100;
        animator = GetComponent<Animator>();
        level =  1;
        name = "Pszemek";
        strength = 10;
        availablePoints = 1;
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
