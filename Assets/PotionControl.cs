using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionControl : MonoBehaviour
{
    public Text text;
    EquipmentSystem equipment;
    void Start()
    {
        text = GetComponent<Text>();
        equipment = PlayerManager.instance.player.GetComponent<EquipmentSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = equipment.Potions.ToString();
    }
}
