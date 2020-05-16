using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVisibilityManager : MonoBehaviour
{
    public Button button;
    private GameManager manager;
    void Start()
    {
        manager = PlayerManager.instance.map.GetComponent<GameManager>();
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isNextLevelPossible)
        {
            button.gameObject.SetActive(true);
        }
    }
}
