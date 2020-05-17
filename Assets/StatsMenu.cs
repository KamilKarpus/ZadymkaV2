using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
	// Start is called before the first frame update
	public Canvas menuUI;
	public Text playerName;
	public Text Level;
	public Text strength;
	public Text health;
	public Text points;
	public Text exp;
	private PlayerStats playerStats;
	void Start()
	{
		playerStats = PlayerManager.instance.player.GetComponentInChildren<PlayerStats>();
		menuUI = GetComponent<Canvas>();
		menuUI.enabled = false;
		Level.text = playerStats.level.ToString();
		playerName.text = playerStats.name;
		strength.text = $"Siła {playerStats.strength}";
		health.text = $"Zdrowie {playerStats.maxHealth}";
		points.text = $"Punkty do rozdania : {playerStats.availablePoints}";
		exp.text = $"Exp: {playerStats.currentExp}/{playerStats.neededExp}";
	}

	// Update is called once per frame
	void Update()
	{
		Level.text = playerStats.level.ToString();
		points.text = $"Punkty do rozdania : {playerStats.availablePoints}";
		exp.text = $"Exp: {playerStats.currentExp}/{playerStats.neededExp}";
		strength.text = $"Siła {playerStats.strength}";
		health.text = $"Zdrowie {playerStats.maxHealth}";
		if (Input.GetKeyUp(KeyCode.C))
		{ //Jeżeli naciśnięto klawisz "Escape"
			menuUI.enabled = !menuUI.enabled;//Ukrycie/pokazanie menu.

			if (menuUI.enabled)
			{
				Time.timeScale = 0;//Zatrzymanie czasu.


			}
			else
			{
				Time.timeScale = 1;//Włączenie czasu.

			}

		}
	}
	public void AddStrenght()
	{
		var result = playerStats.AddStrength();
		if (result)
		{
			strength.text = $"Siła {playerStats.strength}";
			points.text = $"Punkty do rozdania : {playerStats.availablePoints}";
		}
	}

	public void AddHealth()
	{
		var result = playerStats.AddHealth();
		if (result)
		{
			health.text = $"Zdrowie {playerStats.maxHealth}";
			points.text = $"Punkty do rozdania : {playerStats.availablePoints}";
		}
	}
}
