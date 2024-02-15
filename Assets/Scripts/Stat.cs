using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] public abstract class Stat
{
    public int baseStat;
    public int ivStat;
    public int evStat;


    public float natureMultiplier = 1;

    protected Monster parent;

    public abstract int GetFinalStat();

    public void GenerateRandomIV()
    {
        ivStat = Random.Range(0, 32);
    }

    public void SetParent(Monster m)
    {
        parent = m;
    }
}