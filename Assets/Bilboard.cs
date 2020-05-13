using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bilboard : MonoBehaviour
{
    public Transform cam;
    
    private EnemyStats enemyStats;
    public Canvas menuUI;
    // Start is called before the first frame update


    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
        
    }

    //void Update()
    //{
    //    transform.LookAt(transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.down);
    //}
}
