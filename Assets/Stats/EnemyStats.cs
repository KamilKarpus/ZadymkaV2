using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyStats : CharacterStats
{
    private Animator animator;
    public Text changingText;
    public Text nameText;
    public PlayerStats playerStats;
    int deathCounter; 

    public GameObject enemyStats;
    private void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponentInChildren<PlayerStats>();
        level = 1;
        name = "Zombie";
        animator = GetComponent<Animator>();
        deathCounter = 0;
        
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
        }
    }
    public void Update()
    {
        changingText.text = "Lvl. "+level.ToString();
        nameText.text = name;


        enemyStats.SetActive(!isDeath);
        
    }
}
