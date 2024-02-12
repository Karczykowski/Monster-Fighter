using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class TurnManager : MonoBehaviour
{
    public BattleState state;
    [SerializeField] private Station playerStation;
    [SerializeField] private Station enemyStation;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        state = BattleState.START;
    }

    public void PlayTurn(int playerMoveIndex)
    {
        Monster firstMonster;
        Monster secondMonster;
        int enemyMoveIndex = 0;
        if(playerStation.currentMonster.GetSpeed().GetFinalStat() > enemyStation.currentMonster.GetSpeed().GetFinalStat())
        {
            firstMonster = playerStation.currentMonster;
            secondMonster = enemyStation.currentMonster;
            ExecuteAction(playerMoveIndex, true);
            ExecuteAction(enemyMoveIndex, false);
        }
        else
        {
            firstMonster = enemyStation.currentMonster;
            secondMonster = playerStation.currentMonster;
            ExecuteAction(enemyMoveIndex, false);
            ExecuteAction(playerMoveIndex, true);
        }
    }
    public void ExecuteAction(int moveIndex, bool player)
    {
        Move currentMove;
        Monster currentMonster;
        Monster enemyMonster;
        if (player)
        {
            currentMonster = playerStation.currentMonster;
            currentMove = currentMonster.GetMove(moveIndex);
            enemyMonster = enemyStation.currentMonster;
        }
        else
        {
            currentMonster = enemyStation.currentMonster;
            currentMove = currentMonster.GetMove(moveIndex);
            enemyMonster = playerStation.currentMonster;
        }
        
        int baseDamage = GetBaseDamage(currentMove, currentMonster, enemyMonster);
        enemyMonster.GetHp().SetCurrentHp(enemyMonster.GetHp().GetCurrentHp() - baseDamage);

        if (player)
        {
            enemyStation.UpdateHp();
        }
        else
        {
            playerStation.UpdateHp();
        }
    }

    int GetBaseDamage(Move currentMove, Monster currentMonster, Monster enemyMonster)
    {
        int baseDamage = 0;
        int effectiveAttack;
        int effectiveDefense;

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
            baseDamage = (((2 * currentMonster.GetLevel() / 5) + 2) * currentMove.movePower * (effectiveAttack / effectiveDefense) / 50) + 2;
        }
        return baseDamage;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
