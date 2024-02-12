using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class HPStat : Stat
{
    [SerializeField] private int currentHp;
    public override int GetFinalStat()
    {
        return Mathf.FloorToInt((2 * baseStat + ivStat + Mathf.FloorToInt(evStat/4) * parent.GetLevel() )/100) + parent.GetLevel() + 10;
    }

    public void SetCurrentHp(int newHp)
    {
        currentHp = Mathf.Clamp(newHp, 0, GetFinalStat());
    }

    public int GetCurrentHp()
    {
        return currentHp;
    }
}
