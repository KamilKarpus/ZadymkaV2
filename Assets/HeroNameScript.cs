using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroNameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Name;
    public Text Level;

    private PlayerStats playerStats;
    void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponentInChildren<PlayerStats>();
        Name.text = playerStats.name;
        Level.text = playerStats.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Name.text = playerStats.name;
        Level.text = playerStats.level.ToString();
    }
}
