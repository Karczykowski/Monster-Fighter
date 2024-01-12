using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class HPStat : Stat
{
    public override int GetFinalStat(int level)
    {
        return Mathf.FloorToInt((2 * baseStat + ivStat + Mathf.FloorToInt(evStat/4) * level )/100) + level + 10;
    }
}
