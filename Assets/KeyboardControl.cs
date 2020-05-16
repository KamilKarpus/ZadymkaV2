using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{
    PlayerStats stats;
    EquipmentSystem system;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        system = GetComponent<EquipmentSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (stats.RestoreHealth(stats.maxHealth))
            {
                system.UsePotion();
            }
            
        }
    }
}
