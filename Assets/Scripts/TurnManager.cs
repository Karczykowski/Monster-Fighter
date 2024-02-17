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
    [SerializeField] private UI ui;
    [SerializeField] private float actionDelayTime;
    [SerializeField] DamageCalculator damageCalculator;

    private void Start()
    {
        state = BattleState.START;
    }
    public void PlayTurn(int playerMoveIndex)
    {
        StartCoroutine(PlayTurnEnumerator(playerMoveIndex));
    }

    public IEnumerator PlayTurnEnumerator(int playerMoveIndex)
    {
        Monster firstMonster;
        Monster secondMonster;
        int enemyMoveIndex = 0;
        bool isPlayerFaster;

        if(playerStation.currentMonster.GetSpeed().GetFinalStat() > enemyStation.currentMonster.GetSpeed().GetFinalStat())
        {
            firstMonster = playerStation.currentMonster;
            secondMonster = enemyStation.currentMonster;
            isPlayerFaster = true;
        }
        else
        {
            firstMonster = enemyStation.currentMonster;
            secondMonster = playerStation.currentMonster;
            isPlayerFaster = false;
            (enemyMoveIndex, playerMoveIndex) = (playerMoveIndex, enemyMoveIndex);
        }

        // First Monster Attacks
        ui.ShowTextUseMove(firstMonster, firstMonster.GetMove(playerMoveIndex));
        yield return new WaitForSeconds(actionDelayTime);
        Dictionary<string, float> firstMonsterInfo = ExecuteAction(playerMoveIndex, isPlayerFaster);

        if (ui.ShowTextCriticalHit(firstMonsterInfo["critical"]))
        {
            yield return new WaitForSeconds(actionDelayTime);
        }

        if(ui.ShowTextEffectiveness(firstMonsterInfo["type"]))
        {
            yield return new WaitForSeconds(actionDelayTime);
        }
        
        // Second Monster Attacks;
        ui.ShowTextUseMove(secondMonster, secondMonster.GetMove(enemyMoveIndex));
        yield return new WaitForSeconds(actionDelayTime);
        Dictionary<string, float> secondMonsterInfo = ExecuteAction(enemyMoveIndex, !isPlayerFaster);

        if (ui.ShowTextCriticalHit(secondMonsterInfo["critical"]))
        {
            yield return new WaitForSeconds(actionDelayTime);
        }

        if(ui.ShowTextEffectiveness(secondMonsterInfo["type"]))
        {
            yield return new WaitForSeconds(actionDelayTime);
        }

        ui.EnableAttackPanel();
    }
    public Dictionary<string, float> ExecuteAction(int moveIndex, bool player)
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
        
        Dictionary<string, float> DamageInfoList = damageCalculator.GetFinalInfo(currentMove, currentMonster, enemyMonster);
        int finalDamage = (int)DamageInfoList["finalDamage"];

        enemyMonster.GetHp().SetCurrentHp(enemyMonster.GetHp().GetCurrentHp() - finalDamage);

        if (player)
        {
            enemyStation.UpdateHp();
        }
        else
        {
            playerStation.UpdateHp();
        }

        return DamageInfoList;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    
}
