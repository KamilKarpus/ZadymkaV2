using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = .1f;
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        if(speedPercent == 0.00f)
        {
            animator.SetFloat("speedPercent", 0);
            Debug.Log("Idlee");
        }
        else
        {
            animator.SetFloat("speedPercent", 0.49f);
            Debug.Log("Run");
        }
        Debug.Log(speedPercent);
    }
}
