using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class DetectHit : MonoBehaviour
{
    private EnemyStats selfStats;
    private PlayerStats playerStats;
    void Start()
    {
       playerStats = PlayerManager.instance.player.GetComponentInChildren<PlayerStats>();
       selfStats = GetComponent<EnemyStats>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        if(playerStats.isAttacking)
        selfStats.TakeDamage(playerStats.damage.GetValue());
    }
}
