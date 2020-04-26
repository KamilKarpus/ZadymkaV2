using UnityEngine;
using UnityEngine.AI;

public class HeroAnimation : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedPercentage", speedPercent, .1f, Time.deltaTime);
    }    
}
