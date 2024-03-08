using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterSelector : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;

    [SerializeField] private Station playerStation;
    [SerializeField] private Station enemyStation;

    [SerializeField] private List<Monster> InitialPlayerMonsters;
    [SerializeField] private List<Monster> InitialEnemyMonsters;
    private List<Monster> playerMonsters;
    private List<Monster> enemyMonsters;

    [SerializeField] private List<Button> playerTeamButtons;
    [SerializeField] private List<Button> enemyTeamButtons;

    [SerializeField] private Button attackButton;
    [SerializeField] private Button switchButton;

    [SerializeField] private UI ui;

    public bool[] deadMonsters;
    public int currentEnemyIndex;

    private void Start()
    {
        currentEnemyIndex = 0;
        deadMonsters = new bool[InitialPlayerMonsters.Count];
        for(int i=0;i<deadMonsters.Length;i++)
        {
            deadMonsters[i] = false;
        }

        StartGame();
    }

    public void StartGame()
    {
        InstantiatePlayerMonsters();
        InstantiateEnemyMonsters();
        playerStation.SendMonster(playerMonsters[0], 0);
        enemyStation.SendMonster(enemyMonsters[0], 0);
        FillTeamButtons();
        attackButton.interactable = true;
        switchButton.interactable = true;
    }

    private void FillTeamButtons()
    {
        for(int i=0;i<InitialPlayerMonsters.Count;i++)
        {
            playerTeamButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = InitialPlayerMonsters[i].name;
        }
        DisableActiveMonsterSwitch();
    }

    private void DisableActiveMonsterSwitch()
    {
        for (int i = 0; i < InitialPlayerMonsters.Count; i++)
        {
            if (playerStation.currentMonster.name.Contains(playerTeamButtons[i].GetComponentInChildren<TextMeshProUGUI>().text))
            {
                playerTeamButtons[i].interactable = false;
            }
            else
            {
                playerTeamButtons[i].interactable = true;
            }
        }
    }

    private void DisableDeadMonsterSwitch()
    {
        for (int i = 0; i < InitialPlayerMonsters.Count; i++)
        {
            if (deadMonsters[i])
            {
                playerTeamButtons[i].interactable = false;
            }
        }
    }

    public void SwitchMonster(int index)
    {
        playerStation.SendMonster(playerMonsters[index], index);
        DisableActiveMonsterSwitch();
        DisableDeadMonsterSwitch();
        if(turnManager.isCurrentMonsterAlive)
        {
            turnManager.StartCoroutine(turnManager.PlayTurnEnumerator());
        }
        else
        {
            turnManager.isCurrentMonsterAlive = true;
            ui.InfoOption();
        }
    }

    private void InstantiatePlayerMonsters()
    {
        playerMonsters = new List<Monster>();

        foreach (var monster in InitialPlayerMonsters)
        {
            playerMonsters.Add(Instantiate(monster, Vector2.zero, Quaternion.identity));
        }
    }

    private void InstantiateEnemyMonsters()
    {
        enemyMonsters = new List<Monster>();
        foreach (var monster in InitialEnemyMonsters)
        {
            enemyMonsters.Add(Instantiate(monster, Vector2.zero, Quaternion.identity));
        }
    }

    public void setMonsterDead(int index)
    {
        deadMonsters[index] = true;
    }

    public bool areAllMonstersDead()
    {
        bool result = true;
        foreach (var monster in deadMonsters)
        {
            if (!monster)
                return false;
        }
        return result;
    }

    public void printDeadMonsters()
    {
        string result = "";
        foreach(var monster in deadMonsters)
        {
            if (monster == false)
                result += 0;
            else
                result += 1;
        }
        Debug.Log(result);
    }

    public Monster getEnemyMonster(int index)
    {
        return enemyMonsters[index];
    }

    public int getInitialEnemyMonsterLength()
    {
        return InitialEnemyMonsters.Count;
    }
}
