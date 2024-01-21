using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class OtherStat : Stat
{
    public override int GetFinalStat()
    {
        return Mathf.FloorToInt((Mathf.FloorToInt((2 * baseStat + ivStat + Mathf.FloorToInt(evStat / 4)) * parent.GetLevel() / 100) + 5) * natureMultiplier);
    }
}
