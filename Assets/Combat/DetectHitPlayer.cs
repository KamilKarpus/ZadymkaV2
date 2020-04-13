using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHitPlayer : MonoBehaviour
{
    private PlayerStats stats;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;
        var enemyStats = other.gameObject.GetComponentInParent<EnemyStats>();
        if (!enemyStats.isDeath)
        {
            stats.TakeDamage(enemyStats.damage.GetValue());
            Debug.Log($"Player get damage {enemyStats.damage.GetValue()} ");
        }
    }
}
