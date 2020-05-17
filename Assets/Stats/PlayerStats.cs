using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    EquipmentSystem equipment;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        InMemoryCache.currentHealth = currentHealth;
        InMemoryCache.exp = currentExp;
        InMemoryCache.neededExp = neededExp;
    }

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
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            InMemoryCache.maxHealth = maxHealth;
            InMemoryCache.currentHealth = currentHealth;
            InMemoryCache.level = level;
            InMemoryCache.neededExp = neededExp;
            CalculateLevel();
        }
    }
    public bool AddStrength()
    {
        if(availablePoints > 0)
        {
            strength += 10;
            InMemoryCache.strenght = strength;
            availablePoints--;
            return true;
        }
        return false;
    }
    public bool RestoreHealth(int healthToAdd)
    {
        if (currentHealth >= maxHealth)
        {
            return false;
        }
        if (equipment.HasPotions)
        {
            currentHealth += healthToAdd;
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.SetHealth(currentHealth);
            InMemoryCache.maxHealth = maxHealth;
            InMemoryCache.currentHealth = currentHealth;
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
            InMemoryCache.maxHealth = maxHealth;
            InMemoryCache.currentHealth = currentHealth;
            return true;

        }
        return false;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        equipment = GetComponent<EquipmentSystem>();

        if (!InMemoryCache.isMemoryEnabled)
        {
            neededExp = 100;
            level = 1;
            name = "Pszemek";
            strength = 10;
            availablePoints = 1;
            InMemoryCache.isMemoryEnabled = true;
            InMemoryCache.strenght = strength;
            InMemoryCache.maxHealth = maxHealth;
            InMemoryCache.currentHealth = currentHealth;
        }
        else
        {
            neededExp = InMemoryCache.neededExp;
            name = "Pszemek";
            level = InMemoryCache.level;
            equipment = GetComponent<EquipmentSystem>();
            strength = InMemoryCache.strenght;
            currentExp = InMemoryCache.exp;
            maxHealth = InMemoryCache.maxHealth;
            currentHealth = InMemoryCache.currentHealth;
        }
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
