using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    private PlayerStats playerStats;
    public Canvas menuUI;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponentInChildren<PlayerStats>();
        menuUI = GetComponent<Canvas>();
        menuUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.isDeath)
        {
            menuUI.enabled = true;
            Time.timeScale = 0; //Zatrzymanie czasu.
        }
    }
}
