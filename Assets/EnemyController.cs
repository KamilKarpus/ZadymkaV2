using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public bool isAttacking { get; private set; }
    public Transform target;
    NavMeshAgent agent;
    Animator anim;
    EnemyStats stats;
    PlayerStats playerStats;
    public Canvas menuUI;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
        playerStats = PlayerManager.instance.player.GetComponentInChildren<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (!stats.isDeath && !playerStats.isDeath)
        {
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget();
                    anim.SetInteger("animation", 2);
                    isAttacking = true;
                }
                else
                {
                    anim.SetInteger("animation", 1);
                    isAttacking = false;
                }
            }
            else
            {
                anim.SetInteger("animation", 0);
                
            }
        }
        else if(!stats.isDeath && playerStats.isDeath)
        {
            anim.SetInteger("animation", 0);
            isAttacking = false;
            
        }

        if (stats.isDeath)
        {
            menuUI.enabled = false;
        }

    }

    void FaceTarget()
    {
        var direction = (target.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
