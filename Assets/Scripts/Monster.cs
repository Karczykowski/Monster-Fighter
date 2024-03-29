using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Monster : MonoBehaviour
{
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Sprite frontSprite;

    [SerializeField] private string monsterName;
    [SerializeField] private int level = 1;

    [SerializeField] private string natureName;
    [SerializeField] private List<PowerType> monsterTypes = new List<PowerType>();
    [SerializeField] private Move[] moves = new Move[4];

    [SerializeField] private HPStat hp;
    [SerializeField] private OtherStat attack;
    [SerializeField] private OtherStat defense;
    [SerializeField] private OtherStat spattack;
    [SerializeField] private OtherStat spdefense;
    [SerializeField] private OtherStat speed;

    [SerializeField] private int finalAttack;
    [SerializeField] private int finalDefense;
    [SerializeField] private int finalSpecialAttack;
    [SerializeField] private int finalSpecialDefense;
    [SerializeField] private int finalSpeed;

    Dictionary<string, Stat[]> natures = new Dictionary<string, Stat[]>();

    private void Awake()
    {
        CreateNatures(); 
        //natureName = GetRandomNature();
        //AssignNature(natureName);
        //GenerateIV();
        SetParentForStats();
        hp.SetCurrentHp(hp.GetFinalStat());
    }

    private void Start()
    {
        finalAttack = attack.GetFinalStat();
        finalDefense = defense.GetFinalStat();
        finalSpecialAttack = spattack.GetFinalStat();
        finalSpecialDefense = spdefense.GetFinalStat();
        finalSpeed = speed.GetFinalStat();
    }
    private void CreateNatures()
    {
        natures.Add("Hardy", new Stat[0]);
        natures.Add("Lonely", new Stat[2] { attack, defense });
        natures.Add("Brave", new Stat[2] { attack, speed });
        natures.Add("Adamant", new Stat[2] { attack, spattack });
        natures.Add("Naughty", new Stat[2] { attack, spdefense });
        natures.Add("Bold", new Stat[2] { defense, attack });
        natures.Add("Docile", new Stat[0]);
        natures.Add("Relaxed", new Stat[2] { defense, speed });
        natures.Add("Impish", new Stat[2] { defense, spattack });
        natures.Add("Lax", new Stat[2] { defense, spdefense });
        natures.Add("Timid", new Stat[2] { speed, attack });
        natures.Add("Hasty", new Stat[2] { speed, defense });
        natures.Add("Serious", new Stat[0]);
        natures.Add("Jolly", new Stat[2] { speed, spattack });
        natures.Add("Naive", new Stat[2] { speed, spdefense });
        natures.Add("Modest", new Stat[2] { spattack, attack });
        natures.Add("Mild", new Stat[2] { spattack, defense});
        natures.Add("Quiet", new Stat[2] { spattack, speed });
        natures.Add("Bashful", new Stat[0]);
        natures.Add("Rash", new Stat[2] { spattack, spdefense });
        natures.Add("Calm", new Stat[2] { spdefense, attack });
        natures.Add("Gentle", new Stat[2] { spdefense, defense });
        natures.Add("Sassy", new Stat[2] { spdefense, speed });
        natures.Add("Careful", new Stat[2] { spdefense, spattack});
        natures.Add("Quirky", new Stat[0]);
    }

    private string GetRandomNature()
    {
        System.Random rand = new System.Random();
        return natures.ElementAt(rand.Next(0, natures.Count)).Key;
    }

    private void AssignNature(string natureName)
    {
        if (natures[natureName].Length == 0)
            return;
        natures[natureName][0].natureMultiplier = 1.1f;
        natures[natureName][1].natureMultiplier = 0.9f;
    }

    private void GenerateIV()
    {
        hp.GenerateRandomIV();
        attack.GenerateRandomIV();
        defense.GenerateRandomIV();
        spattack.GenerateRandomIV();
        spdefense.GenerateRandomIV();
        speed.GenerateRandomIV();
    }

    private void OnValidate()
    {
        level = Mathf.Clamp(level, 1, 100);
    }

    public int GetLevel()
    {
        return level;
    }

    public HPStat GetHp()
    {
        return hp;
    }

    public Stat GetAttack()
    {
        return attack;
    }

    public Stat GetDefense()
    {
        return defense;
    }

    public Stat GetSpattack()
    {
        return spattack;
    }

    public Stat GetSpdefense()
    {
        return spdefense;
    }

    public Stat GetSpeed()
    {
        return speed;
    }

    public Sprite GetFrontSprite()
    {
        return frontSprite;
    }

    public Sprite GetBackSprite()
    {
        return backSprite;
    }

    public string GetMonsterName()
    {
        return monsterName;
    }

    public Move GetMove(int index)
    {
        return moves[index];
    }

    public void ReadEachMove()
    {
        Debug.Log(moves[0] + ", " + moves[1] + ", " + moves[2] + ", " + moves[3]);
    }
    public int GetMovesSize()
    {
        return moves.Length;
    }

    private void SetParentForStats()
    {
        hp.SetParent(this);
        attack.SetParent(this);
        defense.SetParent(this);
        spattack.SetParent(this);
        spdefense.SetParent(this);
        speed.SetParent(this);
    }

    public List<PowerType> GetMonsterTypes()
    {
        return monsterTypes;
    }
}

