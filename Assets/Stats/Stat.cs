using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField]
    private int _baseValue;
    public Stat(int baseValue)
    {
        _baseValue = baseValue;
    }
    public int GetValue()
    {
        return _baseValue;
    }

    public static Stat operator +(Stat a, Stat b)
    {
        return new Stat(a.GetValue() + b.GetValue());
    }

}
