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

        ui.ShowTextUseMove(firstMonster, firstMonster.GetMove(playerMoveIndex));
        yield return new WaitForSeconds(actionDelayTime);
        ExecuteAction(playerMoveIndex, isPlayerFaster);
        ui.ShowTextEffectiveness(damageCalculator.GetFinalEffectivenessByEnum(firstMonster.GetMove(playerMoveIndex).moveType, secondMonster));
        yield return new WaitForSeconds(actionDelayTime);

        ui.ShowTextUseMove(secondMonster, secondMonster.GetMove(enemyMoveIndex));
        yield return new WaitForSeconds(actionDelayTime);
        ExecuteAction(enemyMoveIndex, !isPlayerFaster);
        ui.ShowTextEffectiveness(damageCalculator.GetFinalEffectivenessByEnum(secondMonster.GetMove(enemyMoveIndex).moveType, firstMonster));
        yield return new WaitForSeconds(actionDelayTime);

        ui.EnableAttackPanel();
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
        
        int finalDamage = damageCalculator.GetFinalDamage(currentMove, currentMonster, enemyMonster);

        enemyMonster.GetHp().SetCurrentHp(enemyMonster.GetHp().GetCurrentHp() - finalDamage);

        if (player)
        {
            enemyStation.UpdateHp();
        }
        else
        {
            playerStation.UpdateHp();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    
}
