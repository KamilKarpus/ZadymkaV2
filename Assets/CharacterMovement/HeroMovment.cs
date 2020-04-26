using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMovment : MonoBehaviour
{
    float speed = 4;
    float rotSpeed = 300;
    float rot = 0f;
    float gravity = 8;
    bool canClick = true;
    int numberOfClick = 0;
    Vector3 moveDir = Vector3.zero;

    public LayerMask mask;

    NavMeshAgent agent;
    public Camera cam;
    CharacterController controller;
    Animator anim;
    PlayerStats stats;
    void Start()
    {
        anim = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stats.isDeath)
        {
            if (Input.GetMouseButtonDown(0))
            {
                stats.isAttacking = false;
                numberOfClick = 0;
                anim.SetInteger("condition", 0);
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        FaceTarget(hit.collider.gameObject.transform);

                    }
                    Attacking();
                }
               
            }   
        }
    }
    void FaceTarget(Transform target)
    {
        var direction = (target.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 250f);
    }
    void Attacking()
    {
        if (canClick)
        {
            numberOfClick++;
            Debug.Log(numberOfClick);
        }
        if (numberOfClick == 1 )
        {
            stats.isAttacking = true;
            anim.SetInteger("condition", 2);
        }
    }
    public void Combo()
    {
        canClick = false;
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") && numberOfClick == 1)
        {
            anim.SetInteger("condition", 0);
            numberOfClick = 0;
            canClick = true;

        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 1") && numberOfClick >= 2)
        {
            anim.SetInteger("condition", 3);
            numberOfClick = 0;
            canClick = true;

        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 3") && numberOfClick == 2)
        {
            anim.SetInteger("condition", 0);
            numberOfClick = 0;
            canClick = true;
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Male Attack 3") && numberOfClick >= 3)
        {
            anim.SetInteger("condition", 4);
            numberOfClick = 0;
            canClick = true;

        }
        else
        { 
            anim.SetInteger("condition", 0);
            numberOfClick = 0;
            canClick = true;
        }
    }
}
