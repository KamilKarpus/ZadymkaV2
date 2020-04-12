using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovment : MonoBehaviour
{
    float speed = 4;
    float runspeed = 5;
    float rotSpeed = 180;
    float rot = 0f;
    float gravity = 8;
    int move = 2;
    bool canClick = true;
    int numberOfClick = 0;
    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 6);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= runspeed;
                moveDir = transform.TransformDirection(moveDir);
                numberOfClick = 0;
                anim.SetBool("isRunning", true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
                numberOfClick = 0;
                anim.SetBool("isRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
                moveDir = Vector3.zero;
                anim.SetBool("isRunning", false);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Attacking();
            }
            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }

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
    public void Sprint()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetInteger("condition", 6);
            }
        }
    }

}
