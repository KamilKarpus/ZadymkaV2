using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat 
{
    [SerializeField]
    private int _baseValue;
    public int GetValue()
    {
        return _baseValue;
    }
}
