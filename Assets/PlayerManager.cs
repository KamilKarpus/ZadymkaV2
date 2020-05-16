using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    void Awake()
    {
        Cursor.visible = true;
        instance = this;
    }

    #endregion
    public GameObject player;
    public GameObject map;

}
