using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour
{
    public Button btnStart;

	public Canvas menuUI;
	// Start is called before the first frame update
	void Start()
    {

		menuUI = (Canvas)GetComponent<Canvas>();
        btnStart = btnStart.GetComponent<Button>();

        Time.timeScale = 0;
        Cursor.visible = menuUI.enabled;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyUp(KeyCode.Escape))
		{ //Jeżeli naciśnięto klawisz "Escape"
			menuUI.enabled = !menuUI.enabled;//Ukrycie/pokazanie menu.

			if (menuUI.enabled)
			{
				Time.timeScale = 0;//Zatrzymanie czasu.
				
				btnStart.enabled = true; //Aktywacja przycsiku 'Start'.
				
			}
			else
			{
				Time.timeScale = 1;//Włączenie czasu.
				
			}

		}
	}

	public void PrzyciskStart()
	{
		//Application.LoadLevel (0); //this will load our first level from our build settings. "1" is the second scene in our game	
		menuUI.enabled = false; //Ukrycie głównego menu.

		Time.timeScale = 1;//Właczenie czasu.

	}
}
