using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour
{
    public Button btnStart;

	public Canvas manuUI;
	// Start is called before the first frame update
	void Start()
    {
        manuUI = (Canvas)GetComponent<Canvas>();
        btnStart = btnStart.GetComponent<Button>();

        Time.timeScale = 0;
        Cursor.visible = manuUI.enabled;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyUp(KeyCode.Escape))
		{ //Jeżeli naciśnięto klawisz "Escape"
			manuUI.enabled = !manuUI.enabled;//Ukrycie/pokazanie menu.

			Cursor.visible = manuUI.enabled;//Ukrycie pokazanie kursora myszy.

			if (manuUI.enabled)
			{
				Cursor.lockState = CursorLockMode.Confined;//Odblokowanie kursora myszy.
				Cursor.visible = true;//Pokazanie kursora.
				Time.timeScale = 0;//Zatrzymanie czasu.
				
				btnStart.enabled = true; //Aktywacja przycsiku 'Start'.
				
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.
				Cursor.visible = false;//Ukrycie kursora.
				Time.timeScale = 1;//Włączenie czasu.
				
			}

		}
	}

	public void PrzyciskStart()
	{
		//Application.LoadLevel (0); //this will load our first level from our build settings. "1" is the second scene in our game	
		manuUI.enabled = false; //Ukrycie głównego menu.

		Time.timeScale = 1;//Właczenie czasu.

		Cursor.visible = false;//Ukrycie kursora.
		Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.
	}
}
