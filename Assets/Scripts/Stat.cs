using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] public abstract class Stat
{
    public int baseStat;
    public int ivStat;
    public int evStat;

    public float natureMultiplier = 1;

    public abstract int GetFinalStat(int level);

    public void GenerateRandomIV()
    {
        ivStat = Random.Range(0, 32);
    }
}