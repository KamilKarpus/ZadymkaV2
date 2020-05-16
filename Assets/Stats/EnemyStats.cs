using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class EnemyStats : CharacterStats
{
    private Guid Id;
    private Animator animator;
    public Text changingText;
    public Text nameText;
    public PlayerStats playerStats;
    public GameManager menager;
    int deathCounter; 

    public GameObject enemyStats;
    private void Start()
    {
        Id = Guid.NewGuid();
        playerStats = PlayerManager.instance.player.GetComponentInChildren<PlayerStats>();
        animator = GetComponent<Animator>();
        deathCounter = 0;
        menager = PlayerManager.instance.map.GetComponent<GameManager>(); 

    }
    protected override void Die()
    {
        animator.SetInteger("animation", 4);
        isDeath = true;
        deathCounter++;
        if (deathCounter == 1)
        {
            var exp = (damage.GetValue() + armor.GetValue()) * level;
            playerStats.currentExp += exp;
            playerStats.CalculateLevel();
            var entity = menager.killedEntities.FirstOrDefault(p => p.Equals(Id));
            if(Guid.Empty == entity)
            {
                menager.killedEntities.Add(Id);
            }
        }
    }
    public void Update()
    {
        changingText.text = "Lvl. "+level.ToString();
        nameText.text = name;


        enemyStats.SetActive(!isDeath);
        
    }
}
