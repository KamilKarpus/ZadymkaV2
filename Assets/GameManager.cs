using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Guid> killedEntities;
    public int entitiesToKill;
    public bool isNextLevelPossible;
    public string NextLevelName;
    void Start()
    {
        killedEntities = new List<Guid>();
        isNextLevelPossible = false;
    }
    void Update()
    {
        if (entitiesToKill == killedEntities.Count)
        {
            isNextLevelPossible = true;
        }
    }
}
