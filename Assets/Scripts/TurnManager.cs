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
        if(playerStation.currentMonster.GetSpeed().GetFinalStat() > enemyStation.currentMonster.GetSpeed().GetFinalStat())
        {
            firstMonster = playerStation.currentMonster;
            secondMonster = enemyStation.currentMonster;
            ui.DisableAttackPanel();
            yield return new WaitForSeconds(actionDelayTime);
            ExecuteAction(playerMoveIndex, true);
            yield return new WaitForSeconds(actionDelayTime);
            ExecuteAction(enemyMoveIndex, false);
            ui.EnableAttackPanel();
        }
        else
        {
            firstMonster = enemyStation.currentMonster;
            secondMonster = playerStation.currentMonster;
            ui.DisableAttackPanel();
            yield return new WaitForSeconds(actionDelayTime);
            ExecuteAction(enemyMoveIndex, false);
            yield return new WaitForSeconds(actionDelayTime);
            ExecuteAction(playerMoveIndex, true);
            ui.EnableAttackPanel();
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
