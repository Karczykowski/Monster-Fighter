using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, float>> powerChart = new Dictionary<string, Dictionary<string, float>>();

    private void Start()
    {
        GenerateTypeChart();
    }
    void GenerateTypeChart()
    {
        // Normal
        AddEffectiveness("Normal", "Normal", 1f);
        AddEffectiveness("Normal", "Fire", 1f);
        AddEffectiveness("Normal", "Water", 1f);
        AddEffectiveness("Normal", "Electric", 1f);
        AddEffectiveness("Normal", "Grass", 1f);
        AddEffectiveness("Normal", "Ice", 1f);
        AddEffectiveness("Normal", "Fighting", 2f);
        AddEffectiveness("Normal", "Poison", 1f);
        AddEffectiveness("Normal", "Ground", 1f);
        AddEffectiveness("Normal", "Flying", 1f);
        AddEffectiveness("Normal", "Psychic", 1f);
        AddEffectiveness("Normal", "Bug", 1f);
        AddEffectiveness("Normal", "Rock", 0.5f);
        AddEffectiveness("Normal", "Ghost", 0f);
        AddEffectiveness("Normal", "Dragon", 1f);
        AddEffectiveness("Normal", "Dark", 1f);
        AddEffectiveness("Normal", "Steel", 0.5f);
        AddEffectiveness("Normal", "Fairy", 1f);

        // Fire
        AddEffectiveness("Fire", "Normal", 1f);
        AddEffectiveness("Fire", "Fire", 0.5f);
        AddEffectiveness("Fire", "Water", 0.5f);
        AddEffectiveness("Fire", "Electric", 1f);
        AddEffectiveness("Fire", "Grass", 2f);
        AddEffectiveness("Fire", "Ice", 2f);
        AddEffectiveness("Fire", "Fighting", 1f);
        AddEffectiveness("Fire", "Poison", 1f);
        AddEffectiveness("Fire", "Ground", 1f);
        AddEffectiveness("Fire", "Flying", 1f);
        AddEffectiveness("Fire", "Psychic", 1f);
        AddEffectiveness("Fire", "Bug", 2f);
        AddEffectiveness("Fire", "Rock", 0.5f);
        AddEffectiveness("Fire", "Ghost", 1f);
        AddEffectiveness("Fire", "Dragon", 0.5f);
        AddEffectiveness("Fire", "Dark", 1f);
        AddEffectiveness("Fire", "Steel", 2f);
        AddEffectiveness("Fire", "Fairy", 1f);

        // Water
        AddEffectiveness("Water", "Normal", 1f);
        AddEffectiveness("Water", "Fire", 2f);
        AddEffectiveness("Water", "Water", 0.5f);
        AddEffectiveness("Water", "Electric", 1f);
        AddEffectiveness("Water", "Grass", 0.5f);
        AddEffectiveness("Water", "Ice", 1f);
        AddEffectiveness("Water", "Fighting", 1f);
        AddEffectiveness("Water", "Poison", 1f);
        AddEffectiveness("Water", "Ground", 2f);
        AddEffectiveness("Water", "Flying", 1f);
        AddEffectiveness("Water", "Psychic", 1f);
        AddEffectiveness("Water", "Bug", 1f);
        AddEffectiveness("Water", "Rock", 2f);
        AddEffectiveness("Water", "Ghost", 1f);
        AddEffectiveness("Water", "Dragon", 0.5f);
        AddEffectiveness("Water", "Dark", 1f);
        AddEffectiveness("Water", "Steel", 1f);
        AddEffectiveness("Water", "Fairy", 1f);

        // Electric
        AddEffectiveness("Electric", "Normal", 1f);
        AddEffectiveness("Electric", "Fire", 1f);
        AddEffectiveness("Electric", "Water", 2f);
        AddEffectiveness("Electric", "Electric", 0.5f);
        AddEffectiveness("Electric", "Grass", 0.5f);
        AddEffectiveness("Electric", "Ice", 1f);
        AddEffectiveness("Electric", "Fighting", 1f);
        AddEffectiveness("Electric", "Poison", 1f);
        AddEffectiveness("Electric", "Ground", 0f);
        AddEffectiveness("Electric", "Flying", 2f);
        AddEffectiveness("Electric", "Psychic", 1f);
        AddEffectiveness("Electric", "Bug", 1f);
        AddEffectiveness("Electric", "Rock", 1f);
        AddEffectiveness("Electric", "Ghost", 1f);
        AddEffectiveness("Electric", "Dragon", 0.5f);
        AddEffectiveness("Electric", "Dark", 1f);
        AddEffectiveness("Electric", "Steel", 1f);
        AddEffectiveness("Electric", "Fairy", 1f);

        // Grass
        AddEffectiveness("Grass", "Normal", 1f);
        AddEffectiveness("Grass", "Fire", 0.5f);
        AddEffectiveness("Grass", "Water", 2f);
        AddEffectiveness("Grass", "Electric", 1f);
        AddEffectiveness("Grass", "Grass", 0.5f);
        AddEffectiveness("Grass", "Ice", 1f);
        AddEffectiveness("Grass", "Fighting", 1f);
        AddEffectiveness("Grass", "Poison", 0.5f);
        AddEffectiveness("Grass", "Ground", 2f);
        AddEffectiveness("Grass", "Flying", 0.5f);
        AddEffectiveness("Grass", "Psychic", 1f);
        AddEffectiveness("Grass", "Bug", 0.5f);
        AddEffectiveness("Grass", "Rock", 2f);
        AddEffectiveness("Grass", "Ghost", 1f);
        AddEffectiveness("Grass", "Dragon", 0.5f);
        AddEffectiveness("Grass", "Dark", 1f);
        AddEffectiveness("Grass", "Steel", 0.5f);
        AddEffectiveness("Grass", "Fairy", 1f);

        // Ice
        AddEffectiveness("Ice", "Normal", 1f);
        AddEffectiveness("Ice", "Fire", 0.5f);
        AddEffectiveness("Ice", "Water", 0.5f);
        AddEffectiveness("Ice", "Electric", 1f);
        AddEffectiveness("Ice", "Grass", 2f);
        AddEffectiveness("Ice", "Ice", 0.5f);
        AddEffectiveness("Ice", "Fighting", 1f);
        AddEffectiveness("Ice", "Poison", 1f);
        AddEffectiveness("Ice", "Ground", 2f);
        AddEffectiveness("Ice", "Flying", 2f);
        AddEffectiveness("Ice", "Psychic", 1f);
        AddEffectiveness("Ice", "Bug", 1f);
        AddEffectiveness("Ice", "Rock", 1f);
        AddEffectiveness("Ice", "Ghost", 1f);
        AddEffectiveness("Ice", "Dragon", 2f);
        AddEffectiveness("Ice", "Dark", 1f);
        AddEffectiveness("Ice", "Steel", 0.5f);
        AddEffectiveness("Ice", "Fairy", 1f);

        // Fighting
        AddEffectiveness("Fighting", "Normal", 2f);
        AddEffectiveness("Fighting", "Fire", 1f);
        AddEffectiveness("Fighting", "Water", 1f);
        AddEffectiveness("Fighting", "Electric", 1f);
        AddEffectiveness("Fighting", "Grass", 1f);
        AddEffectiveness("Fighting", "Ice", 2f);
        AddEffectiveness("Fighting", "Fighting", 1f);
        AddEffectiveness("Fighting", "Poison", 0.5f);
        AddEffectiveness("Fighting", "Ground", 1f);
        AddEffectiveness("Fighting", "Flying", 0.5f);
        AddEffectiveness("Fighting", "Psychic", 0.5f);
        AddEffectiveness("Fighting", "Bug", 0.5f);
        AddEffectiveness("Fighting", "Rock", 2f);
        AddEffectiveness("Fighting", "Ghost", 0f);
        AddEffectiveness("Fighting", "Dragon", 1f);
        AddEffectiveness("Fighting", "Dark", 2f);
        AddEffectiveness("Fighting", "Steel", 2f);
        AddEffectiveness("Fighting", "Fairy", 0.5f);

        // Poison
        AddEffectiveness("Poison", "Normal", 1f);
        AddEffectiveness("Poison", "Fire", 1f);
        AddEffectiveness("Poison", "Water", 1f);
        AddEffectiveness("Poison", "Electric", 1f);
        AddEffectiveness("Poison", "Grass", 2f);
        AddEffectiveness("Poison", "Ice", 1f);
        AddEffectiveness("Poison", "Fighting", 1f);
        AddEffectiveness("Poison", "Poison", 0.5f);
        AddEffectiveness("Poison", "Ground", 0.5f);
        AddEffectiveness("Poison", "Flying", 1f);
        AddEffectiveness("Poison", "Psychic", 1f);
        AddEffectiveness("Poison", "Bug", 1f);
        AddEffectiveness("Poison", "Rock", 0.5f);
        AddEffectiveness("Poison", "Ghost", 0.5f);
        AddEffectiveness("Poison", "Dragon", 1f);
        AddEffectiveness("Poison", "Dark", 1f);
        AddEffectiveness("Poison", "Steel", 0f);
        AddEffectiveness("Poison", "Fairy", 2f);

        // Ground
        AddEffectiveness("Ground", "Normal", 1f);
        AddEffectiveness("Ground", "Fire", 2f);
        AddEffectiveness("Ground", "Water", 1f);
        AddEffectiveness("Ground", "Electric", 2f);
        AddEffectiveness("Ground", "Grass", 0.5f);
        AddEffectiveness("Ground", "Ice", 1f);
        AddEffectiveness("Ground", "Fighting", 1f);
        AddEffectiveness("Ground", "Poison", 2f);
        AddEffectiveness("Ground", "Ground", 1f);
        AddEffectiveness("Ground", "Flying", 0f);
        AddEffectiveness("Ground", "Psychic", 1f);
        AddEffectiveness("Ground", "Bug", 0.5f);
        AddEffectiveness("Ground", "Rock", 2f);
        AddEffectiveness("Ground", "Ghost", 1f);
        AddEffectiveness("Ground", "Dragon", 1f);
        AddEffectiveness("Ground", "Dark", 1f);
        AddEffectiveness("Ground", "Steel", 2f);
        AddEffectiveness("Ground", "Fairy", 1f);

        // Flying
        AddEffectiveness("Flying", "Normal", 1f);
        AddEffectiveness("Flying", "Fire", 1f);
        AddEffectiveness("Flying", "Water", 1f);
        AddEffectiveness("Flying", "Electric", 0.5f);
        AddEffectiveness("Flying", "Grass", 2f);
        AddEffectiveness("Flying", "Ice", 1f);
        AddEffectiveness("Flying", "Fighting", 2f);
        AddEffectiveness("Flying", "Poison", 1f);
        AddEffectiveness("Flying", "Ground", 1f);
        AddEffectiveness("Flying", "Flying", 1f);
        AddEffectiveness("Flying", "Psychic", 1f);
        AddEffectiveness("Flying", "Bug", 2f);
        AddEffectiveness("Flying", "Rock", 0.5f);
        AddEffectiveness("Flying", "Ghost", 1f);
        AddEffectiveness("Flying", "Dragon", 1f);
        AddEffectiveness("Flying", "Dark", 1f);
        AddEffectiveness("Flying", "Steel", 0.5f);
        AddEffectiveness("Flying", "Fairy", 1f);

        // Psychic
        AddEffectiveness("Psychic", "Normal", 1f);
        AddEffectiveness("Psychic", "Fire", 1f);
        AddEffectiveness("Psychic", "Water", 1f);
        AddEffectiveness("Psychic", "Electric", 1f);
        AddEffectiveness("Psychic", "Grass", 1f);
        AddEffectiveness("Psychic", "Ice", 1f);
        AddEffectiveness("Psychic", "Fighting", 2f);
        AddEffectiveness("Psychic", "Poison", 2f);
        AddEffectiveness("Psychic", "Ground", 1f);
        AddEffectiveness("Psychic", "Flying", 1f);
        AddEffectiveness("Psychic", "Psychic", 0.5f);
        AddEffectiveness("Psychic", "Bug", 1f);
        AddEffectiveness("Psychic", "Rock", 1f);
        AddEffectiveness("Psychic", "Ghost", 1f);
        AddEffectiveness("Psychic", "Dragon", 1f);
        AddEffectiveness("Psychic", "Dark", 0f);
        AddEffectiveness("Psychic", "Steel", 0.5f);
        AddEffectiveness("Psychic", "Fairy", 1f);

        // Bug
        AddEffectiveness("Bug", "Normal", 1f);
        AddEffectiveness("Bug", "Fire", 0.5f);
        AddEffectiveness("Bug", "Water", 1f);
        AddEffectiveness("Bug", "Electric", 1f);
        AddEffectiveness("Bug", "Grass", 2f);
        AddEffectiveness("Bug", "Ice", 1f);
        AddEffectiveness("Bug", "Fighting", 0.5f);
        AddEffectiveness("Bug", "Poison", 1f);
        AddEffectiveness("Bug", "Ground", 0.5f);
        AddEffectiveness("Bug", "Flying", 0.5f);
        AddEffectiveness("Bug", "Psychic", 2f);
        AddEffectiveness("Bug", "Bug", 1f);
        AddEffectiveness("Bug", "Rock", 1f);
        AddEffectiveness("Bug", "Ghost", 0.5f);
        AddEffectiveness("Bug", "Dragon", 1f);
        AddEffectiveness("Bug", "Dark", 2f);
        AddEffectiveness("Bug", "Steel", 0.5f);
        AddEffectiveness("Bug", "Fairy", 0.5f);

        // Rock
        AddEffectiveness("Rock", "Normal", 1f);
        AddEffectiveness("Rock", "Fire", 2f);
        AddEffectiveness("Rock", "Water", 1f);
        AddEffectiveness("Rock", "Electric", 1f);
        AddEffectiveness("Rock", "Grass", 1f);
        AddEffectiveness("Rock", "Ice", 2f);
        AddEffectiveness("Rock", "Fighting", 0.5f);
        AddEffectiveness("Rock", "Poison", 1f);
        AddEffectiveness("Rock", "Ground", 0.5f);
        AddEffectiveness("Rock", "Flying", 2f);
        AddEffectiveness("Rock", "Psychic", 1f);
        AddEffectiveness("Rock", "Bug", 2f);
        AddEffectiveness("Rock", "Rock", 1f);
        AddEffectiveness("Rock", "Ghost", 1f);
        AddEffectiveness("Rock", "Dragon", 1f);
        AddEffectiveness("Rock", "Dark", 1f);
        AddEffectiveness("Rock", "Steel", 0.5f);
        AddEffectiveness("Rock", "Fairy", 1f);

        // Ghost
        AddEffectiveness("Ghost", "Normal", 0f);
        AddEffectiveness("Ghost", "Fire", 1f);
        AddEffectiveness("Ghost", "Water", 1f);
        AddEffectiveness("Ghost", "Electric", 1f);
        AddEffectiveness("Ghost", "Grass", 1f);
        AddEffectiveness("Ghost", "Ice", 1f);
        AddEffectiveness("Ghost", "Fighting", 1f);
        AddEffectiveness("Ghost", "Poison", 1f);
        AddEffectiveness("Ghost", "Ground", 1f);
        AddEffectiveness("Ghost", "Flying", 1f);
        AddEffectiveness("Ghost", "Psychic", 1f);
        AddEffectiveness("Ghost", "Bug", 1f);
        AddEffectiveness("Ghost", "Rock", 1f);
        AddEffectiveness("Ghost", "Ghost", 2f);
        AddEffectiveness("Ghost", "Dragon", 1f);
        AddEffectiveness("Ghost", "Dark", 2f);
        AddEffectiveness("Ghost", "Steel", 1f);
        AddEffectiveness("Ghost", "Fairy", 1f);

        // Dragon
        AddEffectiveness("Dragon", "Normal", 1f);
        AddEffectiveness("Dragon", "Fire", 1f);
        AddEffectiveness("Dragon", "Water", 1f);
        AddEffectiveness("Dragon", "Electric", 1f);
        AddEffectiveness("Dragon", "Grass", 1f);
        AddEffectiveness("Dragon", "Ice", 1f);
        AddEffectiveness("Dragon", "Fighting", 1f);
        AddEffectiveness("Dragon", "Poison", 1f);
        AddEffectiveness("Dragon", "Ground", 1f);
        AddEffectiveness("Dragon", "Flying", 1f);
        AddEffectiveness("Dragon", "Psychic", 1f);
        AddEffectiveness("Dragon", "Bug", 1f);
        AddEffectiveness("Dragon", "Rock", 1f);
        AddEffectiveness("Dragon", "Ghost", 1f);
        AddEffectiveness("Dragon", "Dragon", 2f);
        AddEffectiveness("Dragon", "Dark", 1f);
        AddEffectiveness("Dragon", "Steel", 0.5f);
        AddEffectiveness("Dragon", "Fairy", 0f);

        // Dark
        AddEffectiveness("Dark", "Normal", 1f);
        AddEffectiveness("Dark", "Fire", 1f);
        AddEffectiveness("Dark", "Water", 1f);
        AddEffectiveness("Dark", "Electric", 1f);
        AddEffectiveness("Dark", "Grass", 1f);
        AddEffectiveness("Dark", "Ice", 1f);
        AddEffectiveness("Dark", "Fighting", 0.5f);
        AddEffectiveness("Dark", "Poison", 1f);
        AddEffectiveness("Dark", "Ground", 1f);
        AddEffectiveness("Dark", "Flying", 1f);
        AddEffectiveness("Dark", "Psychic", 2f);
        AddEffectiveness("Dark", "Bug", 1f);
        AddEffectiveness("Dark", "Rock", 1f);
        AddEffectiveness("Dark", "Ghost", 2f);
        AddEffectiveness("Dark", "Dragon", 1f);
        AddEffectiveness("Dark", "Dark", 0.5f);
        AddEffectiveness("Dark", "Steel", 1f);
        AddEffectiveness("Dark", "Fairy", 0.5f);

        // Steel
        AddEffectiveness("Steel", "Normal", 1f);
        AddEffectiveness("Steel", "Fire", 0.5f);
        AddEffectiveness("Steel", "Water", 0.5f);
        AddEffectiveness("Steel", "Electric", 0.5f);
        AddEffectiveness("Steel", "Grass", 1f);
        AddEffectiveness("Steel", "Ice", 2f);
        AddEffectiveness("Steel", "Fighting", 1f);
        AddEffectiveness("Steel", "Poison", 1f);
        AddEffectiveness("Steel", "Ground", 1f);
        AddEffectiveness("Steel", "Flying", 1f);
        AddEffectiveness("Steel", "Psychic", 1f);
        AddEffectiveness("Steel", "Bug", 1f);
        AddEffectiveness("Steel", "Rock", 2f);
        AddEffectiveness("Steel", "Ghost", 1f);
        AddEffectiveness("Steel", "Dragon", 1f);
        AddEffectiveness("Steel", "Dark", 1f);
        AddEffectiveness("Steel", "Steel", 0.5f);
        AddEffectiveness("Steel", "Fairy", 2f);

        // Fairy
        AddEffectiveness("Fairy", "Normal", 1f);
        AddEffectiveness("Fairy", "Fire", 0.5f);
        AddEffectiveness("Fairy", "Water", 1f);
        AddEffectiveness("Fairy", "Electric", 1f);
        AddEffectiveness("Fairy", "Grass", 1f);
        AddEffectiveness("Fairy", "Ice", 1f);
        AddEffectiveness("Fairy", "Fighting", 2f);
        AddEffectiveness("Fairy", "Poison", 0.5f);
        AddEffectiveness("Fairy", "Ground", 1f);
        AddEffectiveness("Fairy", "Flying", 1f);
        AddEffectiveness("Fairy", "Psychic", 1f);
        AddEffectiveness("Fairy", "Bug", 1f);
        AddEffectiveness("Fairy", "Rock", 1f);
        AddEffectiveness("Fairy", "Ghost", 1f);
        AddEffectiveness("Fairy", "Dragon", 2f);
        AddEffectiveness("Fairy", "Dark", 2f);
        AddEffectiveness("Fairy", "Steel", 0.5f);
        AddEffectiveness("Fairy", "Fairy", 1f);
    }
    void AddEffectiveness(string attackngType, string defendingType, float value)
    {
        if(!powerChart.ContainsKey(attackngType))
        {
            powerChart[attackngType] = new Dictionary<string, float>();
        }
        powerChart[attackngType][defendingType] = value;
    }

    float GetEffectivenessByString(string attackingType, string defendingType)
    {
        if(powerChart.ContainsKey(attackingType))
        {
            if (powerChart[attackingType].ContainsKey(defendingType))
            {
                return powerChart[attackingType][defendingType];
            }
            else
            {
                Debug.LogError("Defending Type not found" + defendingType);
                return 0;
            }
        }
        else
        {
            Debug.LogError("Attacking Type not found" + attackingType);
            return 0;
        }
    }

    float GetEffectivenessByEnum(PowerType attackingTypeEnum, PowerType defendingTypeEnum)
    {
        string attackingType = attackingTypeEnum.ToString();
        string defendingType = defendingTypeEnum.ToString();
        if (powerChart.ContainsKey(attackingType))
        {
            if (powerChart[attackingType].ContainsKey(defendingType))
            {
                return powerChart[attackingType][defendingType];
            }
            else
            {
                Debug.LogError("Defending Type not found" + defendingType);
                return 0;
            }
        }
        else
        {
            Debug.LogError("Attacking Type not found" + attackingType);
            return 0;
        }
    }
    public float GetBaseDamage(Move currentMove, Monster currentMonster, Monster enemyMonster)
    {
        float baseDamage = 0;
        float effectiveAttack;
        float effectiveDefense;

        if (currentMove.moveCategory == MoveCategory.physical)
        {
            effectiveAttack = currentMonster.GetAttack().GetFinalStat();
            effectiveDefense = enemyMonster.GetDefense().GetFinalStat();
        }
        else
        {
            effectiveAttack = currentMonster.GetSpattack().GetFinalStat();
            effectiveDefense = enemyMonster.GetSpdefense().GetFinalStat();
        }


        if (currentMove.moveCategory != MoveCategory.status)
        {
            baseDamage = (2 * currentMonster.GetLevel() / 5 + 2) * currentMove.movePower * (effectiveAttack / effectiveDefense) / 50 + 2;
        }
        return baseDamage;
    }

    public int GetFinalDamage(Move currentMove, Monster currentMonster, Monster enemyMonster)
    {
        float baseDamage = GetBaseDamage(currentMove, currentMonster, enemyMonster);

        float random = Random.Range(85, 101) / 100f;
        Debug.Log(currentMonster.GetMonsterName() + " Random multiplyer: " + random);

        float stab = 1;
        for(int i = 0; i < currentMonster.GetMonsterTypes().Count; i++)
        {
            if (currentMove.moveType == currentMonster.GetMonsterTypes()[i])
            {
                stab = 1.5f;
                break;
            }
        }

        float type = 1f;
        for (int i=0;i<enemyMonster.GetMonsterTypes().Count;i++)
        {
            type *= GetEffectivenessByEnum(currentMove.moveType, enemyMonster.GetMonsterTypes()[i]);
        }
        Debug.Log(currentMonster.GetMonsterName() + " Type effectiveness: " + type);

        int finalDamage = (int)((int)((int)((int)baseDamage * random) * stab) * type);
        //ShowPossibleDamage((int)(baseDamage * type));
        //int finalDamage = (int)(baseDamage * random * type);
        ShowPossibleDamage(baseDamage, stab, type);
        Debug.Log(currentMonster.GetMonsterName() + " Final Damage: " + finalDamage);

        return finalDamage;
    }

    private void ShowPossibleDamage(float baseDamage, float stab, float type)
    {
        string everyPossibleDmg = "";
        for (float i = 85; i <= 100; i++)
        {
            everyPossibleDmg += (int)((int)((int)((int)baseDamage * i/100) * stab) * type) + ", ";
        }
        Debug.Log(everyPossibleDmg);
    }

}
