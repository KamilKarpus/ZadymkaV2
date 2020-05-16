using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    public int Potions;
    public bool HasPotions { get => Potions > 0; }
    public void UsePotion()
    {
        if (HasPotions)
            Potions--;
    }
    public void AddPotions(int amount)
    {
        Potions = amount;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
