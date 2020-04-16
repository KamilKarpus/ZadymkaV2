using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyStats : CharacterStats
{
    private Animator animator;
    public Text changingText;
    public Text nameText;

    public GameObject enemyStats;
    private void Start()
    {
        level = 1;
        name = "Zombie";
        animator = GetComponent<Animator>();
        
    }
    protected override void Die()
    {
        animator.SetInteger("animation", 4);
        isDeath = true;
    }
    public void Update()
    {
        changingText.text = "Lvl. "+level.ToString();
        nameText.text = name;


        enemyStats.SetActive(!isDeath);
        
    }
}
